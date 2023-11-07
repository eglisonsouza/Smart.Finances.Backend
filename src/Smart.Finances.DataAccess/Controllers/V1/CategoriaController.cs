using Microsoft.AspNetCore.Mvc;
using Smart.Finances.DataAccess.Core.Common.Events;
using Smart.Finances.DataAccess.Event.Commands.CategoriaEvent.Commands;
using Smart.Finances.DataAccess.Event.Queries.ObterTodasCategoria;
using Smart.Finances.DataAccess.Event.ViewModels;

namespace Smart.Finances.DataAccess.Controllers.V1
{
    [Route("api/v1/categorias")]
    public class CategoriaController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get(
            [FromServices] IRequestHandler<ObterTodasCategociaQuery, List<CategoriaViewModel>> handler,
            [FromQuery] ObterTodasCategociaQuery command)
        {
            return Ok(handler.Handle(command));
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
        public ActionResult Put(
            [FromServices] IRequestHandler<EditarCategoriaCommand, CategoriaViewModel> handler,
            [FromBody] EditarCategoriaCommand command
            )
        {
            return Ok(handler.Handle(command));
        }
    }
}
