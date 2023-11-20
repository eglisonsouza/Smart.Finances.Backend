using Smart.Finances.Core.Common.Events;
using Smart.Finances.Core.Entity;
using Smart.Finances.Core.Repositories.Base;
using Smart.Finances.Event.Commands.ParcelaEvent.Commands;
using Smart.Finances.Event.ViewModels;

namespace Smart.Finances.Event.Commands.ParcelaEvent.Handlers
{
    public class PagarParcelaHandler : IRequestHandler<PagarParcelaCommand, ParcelasViewModel>
    {
        private readonly IAtualizaRepository<Parcelas> _repositoryUpdate;
        private readonly IObterPorIdRepository<Parcelas> _obterIdRepository;

        public PagarParcelaHandler(IObterPorIdRepository<Parcelas> obterIdRepository, IAtualizaRepository<Parcelas> repositoryUpdate)
        {
            _obterIdRepository = obterIdRepository;
            _repositoryUpdate = repositoryUpdate;
        }

        public async Task<ParcelasViewModel> Handle(PagarParcelaCommand request)
        {
            var entity = await _obterIdRepository.ObterPorIdAsync(request.IdParcela);

            entity.Pagar();

            var result = await _repositoryUpdate.AtualizarAsync(entity);

            return ParcelasViewModel.FromEntity(result);
        }
    }
}
