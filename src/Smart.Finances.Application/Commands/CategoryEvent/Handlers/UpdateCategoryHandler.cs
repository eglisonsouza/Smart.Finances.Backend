using Smart.Finances.Application.Commands.CategoryEvent.Commands;
using Smart.Finances.Application.ViewModels;
using Smart.Finances.Core.Common.Events;
using Smart.Finances.Core.Entity;
using Smart.Finances.Core.Repositories.Base;
using Smart.Finances.Core.Utils.MessageError;

namespace Smart.Finances.Application.Commands.CategoryEvent.Handlers
{
    public class UpdateCategoryHandler : IRequestHandler<EditCategoryCommand, CategoryViewModel>
    {
        private readonly IUpdateRepository<Category> _updateRepository;
        private readonly IGetByIdRepository<Category> _getByIdRepository;

        public UpdateCategoryHandler(IUpdateRepository<Category> updateRepository, IGetByIdRepository<Category> getByIdRepository)
        {
            _updateRepository = updateRepository;
            _getByIdRepository = getByIdRepository;
        }

        public async Task<CategoryViewModel> Handle(EditCategoryCommand request)
        {
            var category = await _getByIdRepository.GetByIdAsync(request.Id)
                ?? throw new Exception(MessageError.CategoryNotFound);

            category.Update(request.Description);

            var entity = _updateRepository.Update(category);

            return CategoryViewModel.FromEntity(entity);
        }
    }
}
