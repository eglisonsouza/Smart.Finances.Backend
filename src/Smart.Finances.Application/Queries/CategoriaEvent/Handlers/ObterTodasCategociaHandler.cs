using Smart.Finances.Core.Common.Events;
using Smart.Finances.Core.Entity;
using Smart.Finances.Core.Repositories.Base;
using Smart.Finances.Event.Queries.CategoriaEvent.Queries;
using Smart.Finances.Event.ViewModels;

namespace Smart.Finances.Event.Queries.CategoriaEvent.Handlers
{
    public class ObterTodasCategociaHandler : IRequestHandler<ObterTodasCategociaQuery, List<CategoriaViewModel>>
    {
        private readonly IObterTodosRepository<Categoria> _repository;

        public ObterTodasCategociaHandler(IObterTodosRepository<Categoria> repository)
        {
            _repository = repository;
        }

        public async Task<List<CategoriaViewModel>> Handle(ObterTodasCategociaQuery request)
        {
            var categorias = await _repository.ObterTodosAsync();
            return categorias.Select(c => CategoriaViewModel.FromEntity(c)).ToList();
        }
    }
}
