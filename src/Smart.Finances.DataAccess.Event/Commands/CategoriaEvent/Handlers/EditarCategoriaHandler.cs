using Smart.Finances.DataAccess.Core.Common.Events;
using Smart.Finances.DataAccess.Core.Entity;
using Smart.Finances.DataAccess.Core.Repositories.Base;
using Smart.Finances.DataAccess.Event.Commands.CategoriaEvent.Commands;
using Smart.Finances.DataAccess.Event.ViewModels;

namespace Smart.Finances.DataAccess.Event.Commands.CategoriaEvent.Handlers
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

        public Task<CategoriaViewModel> Handle(EditarCategoriaCommand request)
        {
            var categoria = _obterIdRepository
                .ObterPorId(request.Id);

            categoria.Atualizar(request.Descricao);

            var entity = _repositoryUpdate.Atualizar(categoria);

            return Task.FromResult(CategoriaViewModel.FromEntity(entity));
        }
    }
}
