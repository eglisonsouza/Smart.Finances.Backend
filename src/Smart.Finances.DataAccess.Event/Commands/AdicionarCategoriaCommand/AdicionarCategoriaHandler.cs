using Smart.Finances.DataAccess.Core.Common.Events;
using Smart.Finances.DataAccess.Core.Entity;
using Smart.Finances.DataAccess.Core.Repositories.Base;
using Smart.Finances.DataAccess.Event.ViewModels;

namespace Smart.Finances.DataAccess.Event.Commands.AdicionarCategoriaCommand
{
    public class AdicionarCategoriaHandler : IRequestHandler<AdicionarCategoriaCommand, CategoriaViewModel>
    {
        private readonly IAddRepository<Categoria> _repository;

        public AdicionarCategoriaHandler(IAddRepository<Categoria> repository)
        {
            _repository = repository;
        }

        public Task<CategoriaViewModel> Handle(AdicionarCategoriaCommand request)
        {
            var result = _repository.Adicionar(request.ToEntity());

            return Task.FromResult(CategoriaViewModel.FromEntity(result));
        }
    }
}
