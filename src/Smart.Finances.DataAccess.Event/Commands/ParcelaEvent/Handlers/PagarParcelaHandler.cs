using Smart.Finances.DataAccess.Core.Common.Events;
using Smart.Finances.DataAccess.Core.Entity;
using Smart.Finances.DataAccess.Core.Repositories.Base;
using Smart.Finances.DataAccess.Event.Commands.ParcelaEvent.Commands;
using Smart.Finances.DataAccess.Event.ViewModels;

namespace Smart.Finances.DataAccess.Event.Commands.ParcelaEvent.Handlers
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

        public Task<ParcelasViewModel> Handle(PagarParcelaCommand request)
        {
            var entity = _obterIdRepository.ObterPorId(request.IdParcela);

            entity.Pagar();

            var result = _repositoryUpdate.Atualizar(entity);

            return Task.FromResult(ParcelasViewModel.FromEntity(result));
        }
    }
}
