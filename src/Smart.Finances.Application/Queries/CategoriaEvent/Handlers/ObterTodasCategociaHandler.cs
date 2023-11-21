using Smart.Finances.Core.Common.Events;
using Smart.Finances.Core.Entity;
using Smart.Finances.Core.Repositories.Base;
using Smart.Finances.Application.Queries.CategoriaEvent.Queries;
using Smart.Finances.Application.ViewModels;
using Smart.Finances.Infra.MessageBus.Queues.Publishers;

namespace Smart.Finances.Application.Queries.CategoriaEvent.Handlers
{
    public class ObterTodasCategociaHandler : IRequestHandler<ObterTodasCategociaQuery, List<CategoriaViewModel>>
    {
        private readonly IObterTodosRepository<Categoria> _repository;
        private readonly INotificationQueuePublisher _publisher;
        public ObterTodasCategociaHandler(IObterTodosRepository<Categoria> repository, INotificationQueuePublisher publisher)
        {
            _repository = repository;
            _publisher = publisher;
        }

        public async Task<List<CategoriaViewModel>> Handle(ObterTodasCategociaQuery request)
        {
            var categorias = await _repository.ObterTodosAsync();
            return categorias.Select(c => CategoriaViewModel.FromEntity(c)).ToList();
        }
    }
}
