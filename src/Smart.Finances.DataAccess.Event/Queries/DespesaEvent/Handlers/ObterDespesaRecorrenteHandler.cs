using Smart.Finances.DataAccess.Core.Common.Events;
using Smart.Finances.DataAccess.Core.Repositories;
using Smart.Finances.DataAccess.Event.Queries.DespesaEvent.Queries;
using Smart.Finances.DataAccess.Event.ViewModels;

namespace Smart.Finances.DataAccess.Event.Queries.DespesaEvent.Handlers
{
    public class ObterDespesaRecorrenteHandler : IRequestHandler<ObterDespesaRecorrenteQuery, List<DespesaViewModel>>
    {
        private readonly IDespesaRepository _repository;

        public ObterDespesaRecorrenteHandler(IDespesaRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<DespesaViewModel>> Handle(ObterDespesaRecorrenteQuery request)
        {
            var despesas = await _repository.ObterDespesaRecorrenteAsync(request.UsuarioId);

            return DespesaViewModel.FromEntity(despesas);
        }
    }
}
