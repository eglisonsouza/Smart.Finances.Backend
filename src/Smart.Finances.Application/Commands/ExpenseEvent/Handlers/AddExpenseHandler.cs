using Smart.Finances.Application.Commands.ExpenseEvent.Commands;
using Smart.Finances.Application.ViewModels;
using Smart.Finances.Core.Common.Events;
using Smart.Finances.Core.Entity;
using Smart.Finances.Core.Model.Args;
using Smart.Finances.Core.Repositories.Base;
using Smart.Finances.Infra.MessageBus.Queues.Publishers;

namespace Smart.Finances.Application.Commands.ExpenseEvent.Handlers
{
    public class AddExpenseHandler : IRequestHandler<AddExpenseCommand, ExpenseViewModel>
    {
        private readonly IAddRepository<Expense> _expenseRepository;
        private readonly IAddAllRepository<Installment> _installmentRepository;
        private readonly INotificationQueuePublisher _notificationQueuePublisher;

        public AddExpenseHandler(IAddRepository<Expense> repository, IAddAllRepository<Installment> installmentRepository, INotificationQueuePublisher notificationQueuePublisher)
        {
            _expenseRepository = repository;
            _installmentRepository = installmentRepository;
            _notificationQueuePublisher = notificationQueuePublisher;
        }

        public async Task<ExpenseViewModel> Handle(AddExpenseCommand request)
        {
            var entity = await _expenseRepository.AddAsync(request.ToEntity());

            entity.GenerateInstallment(request.FirstDue);

            await _installmentRepository.AddAllAsync(entity.Installments!);

            SendEmail(request.EmailUser!, entity.GenerateMessage());

            return ExpenseViewModel.FromEntity(entity);
        }

        public void SendEmail(string email, string message)
        {
            Task.Run(() => _notificationQueuePublisher.Publish(new EmailArgs(email, message, "Cadastro de Despesa")));
        }
    }
}
