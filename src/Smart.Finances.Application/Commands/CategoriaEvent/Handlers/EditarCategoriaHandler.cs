using Smart.Finances.Core.Common.Events;
using Smart.Finances.Core.Entity;
using Smart.Finances.Core.Repositories.Base;
using Smart.Finances.Application.Commands.CategoriaEvent.Commands;
using Smart.Finances.Application.ViewModels;

namespace Smart.Finances.Application.Commands.CategoriaEvent.Handlers
{
    public class EditarCategoriaHandler : IRequestHandler<EditarCategoriaCommand, CategoriaViewModel>
    {
        private readonly IAtualizaRepository<Categoria> _repositoryUpdate;
        private readonly IObterPorIdRepository<Categoria> _obterIdRepository;

        public EditarCategoriaHandler(IAtualizaRepository<Categoria> repositoryUpdate, IObterPorIdRepository<Categoria> obterIdRepository)
        {
            _repositoryUpdate = repositoryUpdate;
            _obterIdRepository = obterIdRepository;
        }

        public async Task<CategoriaViewModel> Handle(EditarCategoriaCommand request)
        {
            var categoria = await _obterIdRepository
                .ObterPorIdAsync(request.Id);

            categoria.Atualizar(request.Descricao);

            var entity = await _repositoryUpdate.AtualizarAsync(categoria);

            return CategoriaViewModel.FromEntity(entity);
        }
    }
}
