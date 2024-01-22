using NSubstitute;
using Smart.Finances.Application.Commands.CategoryEvent.Commands;
using Smart.Finances.Application.Commands.CategoryEvent.Handlers;
using Smart.Finances.Core.Entity;
using Smart.Finances.Core.Repositories.Base;

namespace Smart.Finances.UnitTest.Application.Commands.CategoryEvent.Handlers
{
    public class UpdateCategoryHandlerTest
    {
        [Fact]
        public async Task Handle_ValidRequest_ReturnsCategoryViewModel()
        {
            // Arrange
            var request = new EditCategoryCommand
            {
                Id = Guid.NewGuid(),
                Description = "New Category Description"
            };

            var getByIdRepository = Substitute.For<IGetByIdRepository<Category>>();
            var updateRepository = Substitute.For<IUpdateRepository<Category>>();

            var handler = new UpdateCategoryHandler(updateRepository, getByIdRepository);

            var existingCategory = new Category(description: "Old Category Description");

            getByIdRepository.GetByIdAsync(request.Id)!.Returns(Task.FromResult(existingCategory));

            updateRepository.Update(existingCategory).Returns(existingCategory);

            // Act
            var result = await handler.Handle(request);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(request.Description, existingCategory.Description);
        }

        [Fact]
        public void Handle_CategoryNotFound_ThrowsException()
        {
            // Arrange
            var request = new EditCategoryCommand
            {
                Id = Guid.NewGuid(),
                Description = "New Category Description"
            };

            var getByIdRepository = Substitute.For<IGetByIdRepository<Category>>();
            var updateRepository = Substitute.For<IUpdateRepository<Category>>();

            var handler = new UpdateCategoryHandler(updateRepository, getByIdRepository);

            getByIdRepository.GetByIdAsync(request.Id)!.Returns(Task.FromResult<Category>(null));

            // Act & Assert
            Assert.ThrowsAsync<Exception>(async () => await handler.Handle(request));
        }
    }
}
