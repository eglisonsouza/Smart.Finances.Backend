using Smart.Finances.Application.Queries.CategoryEvent.Queries;
using Smart.Finances.Application.ViewModels;
using Smart.Finances.Core.Common.Events;
using Smart.Finances.Core.Entity;
using Smart.Finances.Core.Repositories.Base;

namespace Smart.Finances.Application.Queries.CategoryEvent.Handlers
{
    public class GetAllCategoryHandler : IRequestHandler<GetAllCategoryQuery, List<CategoryViewModel>>
    {
        private readonly IGetAllRepository<Category> _repository;
        public GetAllCategoryHandler(IGetAllRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task<List<CategoryViewModel>> Handle(GetAllCategoryQuery request)
        {
            var categories = await _repository.GetAllAsync();
            return CategoryViewModel.FromEntity(categories);
        }
    }
}
