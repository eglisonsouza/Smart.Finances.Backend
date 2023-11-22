using Smart.Finances.Application.Queries.ExpenseEvent.Queries;
using Smart.Finances.Application.ViewModels;
using Smart.Finances.Core.Common.Events;
using Smart.Finances.Core.Repositories;

namespace Smart.Finances.Application.Queries.ExpenseEvent.Handlers
{
    public class GetExpenseHandler : IRequestHandler<GetExpenseQuery, List<ExpenseViewModel>>
    {
        private readonly IExpenseRepository _repository;

        public GetExpenseHandler(IExpenseRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ExpenseViewModel>> Handle(GetExpenseQuery request)
        {
            var expenses = await _repository.GetByMonthAsync(request.ReferenceMonth, request.UserId);

            return ExpenseViewModel.FromEntity(expenses);
        }
    }
}
