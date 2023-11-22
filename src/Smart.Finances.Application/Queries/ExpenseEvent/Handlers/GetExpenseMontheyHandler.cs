using Smart.Finances.Application.Queries.ExpenseEvent.Queries;
using Smart.Finances.Application.ViewModels;
using Smart.Finances.Core.Common.Events;
using Smart.Finances.Core.Repositories;

namespace Smart.Finances.Application.Queries.ExpenseEvent.Handlers
{
    public class GetExpenseMontheyHandler : IRequestHandler<GetExpenseMontheyQuery, List<ExpenseViewModel>>
    {
        private readonly IExpenseRepository _repository;

        public GetExpenseMontheyHandler(IExpenseRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ExpenseViewModel>> Handle(GetExpenseMontheyQuery request)
        {
            var expenses = await _repository.GetExpenseMontheyAsync(request.UserId);

            return ExpenseViewModel.FromEntity(expenses);
        }
    }
}
