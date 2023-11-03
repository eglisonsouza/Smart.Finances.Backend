using Microsoft.AspNetCore.Mvc;
using Smart.Finances.DataAccess.Core.Common.Events;
using Smart.Finances.DataAccess.Event.Commands;
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

        [HttpPatch]
        public ActionResult Patch()
        {
            return Ok();
        }
    }
}
