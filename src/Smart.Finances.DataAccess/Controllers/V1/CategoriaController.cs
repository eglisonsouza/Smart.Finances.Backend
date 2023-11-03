using Microsoft.AspNetCore.Mvc;
using Smart.Finances.DataAccess.Core.Common.Events;
using Smart.Finances.DataAccess.Event.Commands.AdicionarCategoriaCommand;
using Smart.Finances.DataAccess.Event.Commands.EditarCategoriaCommand;
using Smart.Finances.DataAccess.Event.ViewModels;

namespace Smart.Finances.DataAccess.Controllers.V1
{
    [Route("api/v1/categorias")]
    public class CategoriaController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            return Ok();
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
