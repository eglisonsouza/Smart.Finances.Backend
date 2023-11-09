using Smart.Finances.DataAccess.Core.Common.Events;
using Smart.Finances.DataAccess.Core.Entity;
using Smart.Finances.DataAccess.Core.Repositories.Base;
using Smart.Finances.DataAccess.Event.Queries.CategoriaEvent.Queries;
using Smart.Finances.DataAccess.Event.ViewModels;

namespace Smart.Finances.DataAccess.Event.Queries.CategoriaEvent.Handlers
{
    public class ObterTodasCategociaHandler : IRequestHandler<ObterTodasCategociaQuery, List<CategoriaViewModel>>
    {
        private readonly IObterTodosRepository<Categoria> _repository;

        public ObterTodasCategociaHandler(IObterTodosRepository<Categoria> repository)
        {
            _repository = repository;
        }

        public Task<List<CategoriaViewModel>> Handle(ObterTodasCategociaQuery request)
        {
            var categorias = _repository.ObterTodos()
                                .Select(c => CategoriaViewModel.FromEntity(c)).ToList();
            return Task.FromResult(categorias);
        }
    }
}
