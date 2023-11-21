using Smart.Finances.Core.Common.Events;
using Smart.Finances.Core.Entity;
using Smart.Finances.Core.Repositories.Base;
using Smart.Finances.Application.Commands.ParcelaEvent.Commands;
using Smart.Finances.Application.ViewModels;
using Smart.Finances.Infra.MessageBus.Queues.Publishers;
using Smart.Finances.Core.Model.Args;

namespace Smart.Finances.Application.Commands.ParcelaEvent.Handlers
{
    public class PagarParcelaHandler : IRequestHandler<PagarParcelaCommand, ParcelasViewModel>
    {
        private readonly IAtualizaRepository<Parcelas> _repositoryUpdate;
        private readonly IObterPorIdRepository<Parcelas> _obterIdRepository;
        private readonly INotificationQueuePublisher _notificationQueuePublisher;

        public PagarParcelaHandler(IObterPorIdRepository<Parcelas> obterIdRepository, IAtualizaRepository<Parcelas> repositoryUpdate, INotificationQueuePublisher notificationQueuePublisher)
        {
            _obterIdRepository = obterIdRepository;
            _repositoryUpdate = repositoryUpdate;
            _notificationQueuePublisher = notificationQueuePublisher;
        }

        public async Task<ParcelasViewModel> Handle(PagarParcelaCommand request)
        {
            var entity = await _obterIdRepository.ObterPorIdAsync(request.IdParcela);

            entity.Pagar();

            var result = await _repositoryUpdate.AtualizarAsync(entity);

            SendEmail(request.EmailUsuario, entity.GerarMensagem());

            return ParcelasViewModel.FromEntity(result);
        }

        private void SendEmail(string emailUsuario, string mensagem)
        {
            Task.Run(() => _notificationQueuePublisher.Publish(new EmailArgs(emailUsuario, mensagem, "Pagamento de Parcela")));
        }
    }
}
