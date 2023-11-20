using Microsoft.AspNetCore.Mvc;
using Smart.Finances.Core.Common.Events;
using Smart.Finances.Event.Commands.ParcelaEvent.Commands;
using Smart.Finances.Event.ViewModels;

namespace Smart.Finances.Controllers.V1
{
    [Route("api/v1/parcela")]
    public class ParcelaController : ControllerBase
    {
        [HttpPatch]
        [Route("pagar")]
        public async Task<IActionResult> Pagar([FromServices] IRequestHandler<PagarParcelaCommand, ParcelasViewModel> handler,
            [FromQuery] PagarParcelaCommand command)
        {
            return Ok(await handler.Handle(command));
        }
    }
}
