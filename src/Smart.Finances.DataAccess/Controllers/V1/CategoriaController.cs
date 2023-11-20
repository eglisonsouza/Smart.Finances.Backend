using Microsoft.AspNetCore.Mvc;
using Smart.Finances.DataAccess.Core.Common.Events;
using Smart.Finances.DataAccess.Event.Commands.CategoriaEvent.Commands;
using Smart.Finances.DataAccess.Event.Queries.CategoriaEvent.Queries;
using Smart.Finances.DataAccess.Event.ViewModels;

namespace Smart.Finances.DataAccess.Controllers.V1
{
    [Route("api/v1/categorias")]
    public class CategoriaController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> Get(
            [FromServices] IRequestHandler<ObterTodasCategociaQuery, List<CategoriaViewModel>> handler,
            [FromQuery] ObterTodasCategociaQuery query)
        {
            return Ok(await handler.Handle(query));
        }

        [HttpPost]
        public ActionResult Post(
            [FromServices] IRequestHandler<AdicionarCategoriaCommand, CategoriaViewModel> handler,
            [FromBody] AdicionarCategoriaCommand command
            )
        {
            return Ok(handler.Handle(command));
        }

        [HttpPut]
        public async Task<ActionResult> Put(
            [FromServices] IRequestHandler<EditarCategoriaCommand, CategoriaViewModel> handler,
            [FromBody] EditarCategoriaCommand command
            )
        {
            return Ok(await handler.Handle(command));
        }
    }
}
