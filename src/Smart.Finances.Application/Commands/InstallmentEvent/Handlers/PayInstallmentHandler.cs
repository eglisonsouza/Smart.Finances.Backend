using Smart.Finances.Application.Commands.InstallmentEvent.Commands;
using Smart.Finances.Application.ViewModels;
using Smart.Finances.Core.Common.Events;
using Smart.Finances.Core.Entity;
using Smart.Finances.Core.Model.Args;
using Smart.Finances.Core.Repositories.Base;
using Smart.Finances.Core.Utils.MessageError;
using Smart.Finances.Infra.MessageBus.Queues.Publishers;

namespace Smart.Finances.Application.Commands.InstallmentEvent.Handlers
{
    public class PayInstallmentHandler : IRequestHandler<PayInstallmentCommand, InstallmentViewModel>
    {
        private readonly IUpdateRepository<Installment> _updateRepository;
        private readonly IGetByIdRepository<Installment> _getByIdRepository;
        private readonly INotificationQueuePublisher _notificationQueuePublisher;

        public PayInstallmentHandler(IGetByIdRepository<Installment> getByIdRepository, IUpdateRepository<Installment> updateRepository, INotificationQueuePublisher notificationQueuePublisher)
        {
            _getByIdRepository = getByIdRepository;
            _updateRepository = updateRepository;
            _notificationQueuePublisher = notificationQueuePublisher;
        }

        public async Task<InstallmentViewModel> Handle(PayInstallmentCommand request)
        {
            var entity = await _getByIdRepository.GetByIdAsync(request.InstallmentId)
                ?? throw new Exception(MessageError.InstallmentNotFound);

            entity.Pay();

            var result = _updateRepository.Update(entity);

            SendEmail(request.UserEmail!, entity.GenerateMessage());

            return InstallmentViewModel.FromEntity(result);
        }

        private void SendEmail(string email, string message)
        {
            Task.Run(() => _notificationQueuePublisher.Publish(new EmailArgs(email, message, "Pagamento de Parcela")));
        }
    }
}
