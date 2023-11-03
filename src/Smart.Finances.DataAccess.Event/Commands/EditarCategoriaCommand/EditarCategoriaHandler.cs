using Smart.Finances.DataAccess.Core.Common.Events;
using Smart.Finances.DataAccess.Core.Repositories;
using Smart.Finances.DataAccess.Event.ViewModels;

namespace Smart.Finances.DataAccess.Event.Commands.EditarCategoriaCommand
{
    public class EditarCategoriaHandler : IRequestHandler<EditarCategoriaCommand, CategoriaViewModel>
    {
        private readonly ICategoriaRepository _repository;

        public EditarCategoriaHandler(ICategoriaRepository repository)
        {
            _repository = repository;
        }

        public Task<CategoriaViewModel> Handle(EditarCategoriaCommand request)
        {
            var categoria = _repository
                .ObterPorId(request.Id);

            categoria.Atualizar(request.Descricao);

            var entity = _repository.Atualizar(categoria);

            return Task.FromResult(CategoriaViewModel.FromEntity(entity));
        }
    }
}
