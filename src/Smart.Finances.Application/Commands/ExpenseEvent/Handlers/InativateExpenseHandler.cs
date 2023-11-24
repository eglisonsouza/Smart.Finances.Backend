using Smart.Finances.Application.Commands.ExpenseEvent.Commands;
using Smart.Finances.Application.ViewModels;
using Smart.Finances.Core.Common.Events;
using Smart.Finances.Core.Entity;
using Smart.Finances.Core.Repositories.Base;
using Smart.Finances.Core.Utils.MessageError;

namespace Smart.Finances.Application.Commands.ExpenseEvent.Handlers
{
    public class InativateExpenseHandler : IRequestHandler<InactivateExpenseCommand, ExpenseViewModel>
    {
        private readonly IUpdateRepository<Expense> _updateRepository;
        private readonly IGetByIdRepository<Expense> _getByIdRepository;

        public InativateExpenseHandler(IGetByIdRepository<Expense> getByIdRepository, IUpdateRepository<Expense> updateRepository)
        {
            _getByIdRepository = getByIdRepository;
            _updateRepository = updateRepository;
        }

        public async Task<ExpenseViewModel> Handle(InactivateExpenseCommand request)
        {
            var entity = await _getByIdRepository.GetByIdAsync(request.ExpenseId);

            if (entity is null)
                throw new Exception(MessageError.ExpenseNotFound);

            entity.Inativate();
            var result = _updateRepository.Update(entity);
            return ExpenseViewModel.FromEntity(result);
        }
    }
}
