using Microsoft.AspNetCore.Mvc;
using Smart.Finances.DataAccess.Core.Common.Events;
using Smart.Finances.DataAccess.Event.Commands.ParcelaEvent.Commands;
using Smart.Finances.DataAccess.Event.ViewModels;

namespace Smart.Finances.DataAccess.Controllers.V1
{
    [Route("api/v1/parcela")]
    public class ParcelaController : ControllerBase
    {
        [HttpPatch]
        [Route("pagar")]
        public IActionResult Pagar([FromServices] IRequestHandler<PagarParcelaCommand, ParcelasViewModel> handler,
            [FromQuery] PagarParcelaCommand command)
        {
            return Ok(handler.Handle(command));
        }
    }
}
