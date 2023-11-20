using Smart.Finances.Core.Common.Events;
using Smart.Finances.Core.Entity;
using Smart.Finances.Core.Repositories.Base;
using Smart.Finances.Event.Commands.CategoriaEvent.Commands;
using Smart.Finances.Event.ViewModels;

namespace Smart.Finances.Event.Commands.CategoriaEvent.Handlers
{
    public class AdicionarCategoriaHandler : IRequestHandler<AdicionarCategoriaCommand, CategoriaViewModel>
    {
        private readonly IAddRepository<Categoria> _repository;

        public AdicionarCategoriaHandler(IAddRepository<Categoria> repository)
        {
            _repository = repository;
        }

        public async Task<CategoriaViewModel> Handle(AdicionarCategoriaCommand request)
        {
            var result = await _repository.AdicionarAsync(request.ToEntity());

            return CategoriaViewModel.FromEntity(result);
        }
    }
}
