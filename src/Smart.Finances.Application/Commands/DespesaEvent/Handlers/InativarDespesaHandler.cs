using Smart.Finances.Core.Common.Events;
using Smart.Finances.Core.Entity;
using Smart.Finances.Core.Repositories.Base;
using Smart.Finances.Application.Commands.DespesaEvent.Commands;
using Smart.Finances.Application.ViewModels;

namespace Smart.Finances.Application.Commands.DespesaEvent.Handlers
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
