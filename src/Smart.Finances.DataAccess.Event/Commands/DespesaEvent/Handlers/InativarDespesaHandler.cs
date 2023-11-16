using Smart.Finances.DataAccess.Core.Common.Events;
using Smart.Finances.DataAccess.Core.Entity;
using Smart.Finances.DataAccess.Core.Repositories.Base;
using Smart.Finances.DataAccess.Event.Commands.DespesaEvent.Commands;
using Smart.Finances.DataAccess.Event.ViewModels;

namespace Smart.Finances.DataAccess.Event.Commands.DespesaEvent.Handlers
{
    public class InativarDespesaHandler : IRequestHandler<InativarDespesaCommand, DespesaViewModel>
    {
        private readonly IAtualizaRepository<Despesa> _repositoryUpdate;
        private readonly IObterPorIdRepository<Despesa> _obterIdRepository;

        public InativarDespesaHandler(IObterPorIdRepository<Despesa> obterIdRepository, IAtualizaRepository<Despesa> repositoryUpdate)
        {
            _obterIdRepository = obterIdRepository;
            _repositoryUpdate = repositoryUpdate;
        }

        public async Task<DespesaViewModel> Handle(InativarDespesaCommand request)
        {
            var entity = await _obterIdRepository.ObterPorIdAsync(request.DespesaId);
            entity.Inativar();
            var result = await _repositoryUpdate.AtualizarAsync(entity);
            return DespesaViewModel.FromEntity(result);
        }
    }
}
