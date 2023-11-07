
using Microsoft.AspNetCore.Mvc;
using Smart.Finances.DataAccess.Core.Common.Events;
using Smart.Finances.DataAccess.Event.Commands.DespesaEvent.Commands;
using Smart.Finances.DataAccess.Event.ViewModels;

namespace Smart.Finances.DataAccess.Controllers.V1
{
    [Route("api/v1/despesa")]
    public class DespesaController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromServices] IRequestHandler<CadastrarDespesaCommand, DespesaViewModel> handler,
            [FromQuery] CadastrarDespesaCommand command)
        {
            return Ok(handler.Handle(command));
        }
    }
}
