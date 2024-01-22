using NSubstitute;
using Smart.Finances.Application.Commands.ExpenseEvent.Commands;
using Smart.Finances.Application.Commands.ExpenseEvent.Handlers;
using Smart.Finances.Core.Entity;
using Smart.Finances.Core.Repositories.Base;
using Smart.Finances.Infra.MessageBus.Queues.Publishers;

namespace Smart.Finances.UnitTest.Application.Commands.ExpenseEvent.Handlers
{
    public class AddExpenseHandlerTest
    {
        [Fact]
        public async Task Handle_ValidRequest_ReturnsExpenseViewModel()
        {
            // Arrange
            var request = new AddExpenseCommand
            {
                Description = "New Expense Description",
                Value = 100,
                CategoryId = Guid.NewGuid(),
                FirstDue = DateTime.Now,
                EmailUser = "",
                IsMonthly = false,
                QuantityInstallment = 3,
                UserId = Guid.NewGuid()
            };

            var addRepository = Substitute.For<IAddRepository<Expense>>();
            var addAllRepository = Substitute.For<IAddAllRepository<Installment>>();
            var notificationQueuePublisher = Substitute.For<INotificationQueuePublisher>();

            var handler = new AddExpenseHandler(addRepository, addAllRepository, notificationQueuePublisher);

            var existingExpense = request.ToEntity();

            addRepository.AddAsync(Arg.Any<Expense>()).Returns(Task.FromResult(existingExpense));

            // Act
            var result = await handler.Handle(request);
            Assert.NotNull(result);
            Assert.Equal(request.Description, existingExpense.Description);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(request.Description, existingExpense.Description);
        }

    }
}
