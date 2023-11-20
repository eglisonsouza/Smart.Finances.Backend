using Smart.Finances.Core.Common.Events;
using Smart.Finances.Core.Repositories;
using Smart.Finances.Application.Queries.DespesaEvent.Queries;
using Smart.Finances.Application.ViewModels;

namespace Smart.Finances.Application.Queries.DespesaEvent.Handlers
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
