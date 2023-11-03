using Smart.Finances.DataAccess.Core.Common.Events;
using Smart.Finances.DataAccess.Core.Repositories;
using Smart.Finances.DataAccess.Event.ViewModels;

namespace Smart.Finances.DataAccess.Event.Queries.ObterTodasCategoria
{
    public class ObterTodasCategociaHandler : IRequestHandler<ObterTodasCategociaQuery, List<CategoriaViewModel>>
    {
        private readonly ICategoriaRepository _repository;

        public ObterTodasCategociaHandler(ICategoriaRepository repository)
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
