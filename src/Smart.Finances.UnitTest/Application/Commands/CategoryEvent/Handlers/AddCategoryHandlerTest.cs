
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using Smart.Finances.Application.Commands.CategoryEvent.Commands;
using Smart.Finances.Application.Commands.CategoryEvent.Handlers;
using Smart.Finances.Core.Entity;
using Smart.Finances.Core.Repositories.Base;

namespace Smart.Finances.UnitTest.Application.Commands.CategoryEvent.Handlers
{
    public class AddCategoryHandlerTest
    {
        [Fact]
        public async Task Handle_ShouldReturnCategoryViewModel()
        {
            // Arrange
            var mockRepository = Substitute.For<IAddRepository<Category>>();
            var handler = new AddCategoryHandler(mockRepository);
            var command = new AddCategoryCommand
            {
                Description = "Test"
            };

            mockRepository.AddAsync(Arg.Any<Category>())
                          .Returns(new Category("Test"));

            // Act
            var result = await handler.Handle(command);

            // Assert
            Assert.NotNull(result);
            await mockRepository.Received(1).AddAsync(Arg.Any<Category>());
        }

        [Fact]
        public async Task Handle_ShouldReturnException()
        {
            // Arrange
            var mockRepository = Substitute.For<IAddRepository<Category>>();
            var handler = new AddCategoryHandler(mockRepository);
            var command = new AddCategoryCommand
            {
                Description = null
            };

            mockRepository.AddAsync(Arg.Any<Category>())
                          .Returns(new Category("Test"));

            await Assert.ThrowsAsync<ArgumentNullException>(() => handler.Handle(command));
        }
    }
}
