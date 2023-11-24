using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Smart.Finances.Application.Commands.InstallmentEvent.Commands;
using Smart.Finances.Application.ViewModels;
using Smart.Finances.Core.Common.Events;
using Smart.Finances.Core.Constraints;

namespace Smart.Finances.Controllers.V1
{
    [Authorize(Roles = RolesUser.UserApp)]
    [Route("api/v1/installment")]
    [ApiController]
    public class InstallmentController : ControllerBase
    {
        [HttpPatch]
        [Route("pay")]
        public async Task<IActionResult> PayAsync([FromServices] IRequestHandler<PayInstallmentCommand, InstallmentViewModel> handler,
            PayInstallmentCommand command)
        {
            return Ok(await handler.Handle(command));
        }
    }
}
