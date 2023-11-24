
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Smart.Finances.Application.Commands.ExpenseEvent.Commands;
using Smart.Finances.Application.Queries.ExpenseEvent.Queries;
using Smart.Finances.Application.ViewModels;
using Smart.Finances.Core.Common.Events;
using Smart.Finances.Core.Constraints;

namespace Smart.Finances.Controllers.V1
{
    [Authorize(Roles = RolesUser.UserApp)]
    [Route("api/v1/expense")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromServices] IRequestHandler<AddExpenseCommand, ExpenseViewModel> handler,
            AddExpenseCommand command)
        {
            return Ok(await handler.Handle(command));
        }

        [HttpPatch("inactivate")]
        public async Task<IActionResult> Inactivate([FromServices] IRequestHandler<InactivateExpenseCommand, ExpenseViewModel> handler,
            InactivateExpenseCommand command)
        {
            return Ok(await handler.Handle(command));
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromServices] IRequestHandler<GetExpenseQuery, List<ExpenseViewModel>> handler,
            [FromQuery] GetExpenseQuery query)
        {
            return Ok(await handler.Handle(query));
        }

        [HttpGet("monthey")]
        public async Task<IActionResult> Get([FromServices] IRequestHandler<GetExpenseMontheyQuery, List<ExpenseViewModel>> handler,
            GetExpenseMontheyQuery query)
        {
            return Ok(await handler.Handle(query));
        }
    }
}
