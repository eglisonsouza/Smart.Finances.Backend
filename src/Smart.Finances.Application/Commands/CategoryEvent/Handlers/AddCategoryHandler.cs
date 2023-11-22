using Smart.Finances.Application.Commands.CategoryEvent.Commands;
using Smart.Finances.Application.ViewModels;
using Smart.Finances.Core.Common.Events;
using Smart.Finances.Core.Entity;
using Smart.Finances.Core.Repositories.Base;

namespace Smart.Finances.Application.Commands.CategoryEvent.Handlers
{
    public class AddCategoryHandler : IRequestHandler<AddCategoryCommand, CategoryViewModel>
    {
        private readonly IAddRepository<Category> _repository;

        public AddCategoryHandler(IAddRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task<CategoryViewModel> Handle(AddCategoryCommand request)
        {
            var result = await _repository.AddAsync(request.ToEntity());

            return CategoryViewModel.FromEntity(result);
        }
    }
}
