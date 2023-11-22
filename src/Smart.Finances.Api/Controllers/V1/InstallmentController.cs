using Microsoft.AspNetCore.Mvc;
using Smart.Finances.Core.Common.Events;
using Smart.Finances.Application.Commands.InstallmentEvent.Commands;
using Smart.Finances.Application.ViewModels;

namespace Smart.Finances.Controllers.V1
{
    [Route("api/v1/installment")]
    public class InstallmentController : ControllerBase
    {
        [HttpPatch]
        [Route("pay")]
        public async Task<IActionResult> PayAsync([FromServices] IRequestHandler<PayInstallmentCommand, InstallmentViewModel> handler,
            [FromQuery] PayInstallmentCommand command)
        {
            return Ok(await handler.Handle(command));
        }
    }
}
