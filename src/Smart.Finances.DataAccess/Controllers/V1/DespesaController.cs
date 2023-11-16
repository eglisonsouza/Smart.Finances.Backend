
using Microsoft.AspNetCore.Mvc;
using Smart.Finances.DataAccess.Core.Common.Events;
using Smart.Finances.DataAccess.Event.Commands.DespesaEvent.Commands;
using Smart.Finances.DataAccess.Event.Queries.DespesaEvent.Queries;
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

        [HttpPatch("inativar")]
        public IActionResult Pagar([FromServices] IRequestHandler<InativarDespesaCommand, DespesaViewModel> handler,
            [FromQuery] InativarDespesaCommand command)
        {
            return Ok(handler.Handle(command));
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromServices] IRequestHandler<ObterDespesaQuery, List<DespesaViewModel>> handler,
            [FromQuery] ObterDespesaQuery query)
        {
            return Ok(await handler.Handle(query));
        }

        [HttpGet("recorrente")]
        public async Task<IActionResult> Get([FromServices] IRequestHandler<ObterDespesaRecorrenteQuery, List<DespesaViewModel>> handler,
            [FromQuery] ObterDespesaRecorrenteQuery query)
        {
            return Ok(await handler.Handle(query));
        }
    }
}
