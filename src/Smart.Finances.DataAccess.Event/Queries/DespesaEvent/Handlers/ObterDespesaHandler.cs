using Smart.Finances.DataAccess.Core.Common.Events;
using Smart.Finances.DataAccess.Core.Repositories;
using Smart.Finances.DataAccess.Event.Queries.DespesaEvent.Queries;
using Smart.Finances.DataAccess.Event.ViewModels;

namespace Smart.Finances.DataAccess.Event.Queries.DespesaEvent.Handlers
{
    public class ObterDespesaHandler : IRequestHandler<ObterDespesaQuery, List<DespesaViewModel>>
    {
        private readonly IDespesaRepository _repository;

        public ObterDespesaHandler(IDespesaRepository repository)
        {
            _repository = repository;
        }

        public Task<List<DespesaViewModel>> Handle(ObterDespesaQuery request)
        {
            var despesas = _repository.ObterDespesaPorMes(request.MesReferencia, request.UsuarioId);

            return Task.FromResult(DespesaViewModel.FromEntity(despesas));
        }
    }
}
