using Microsoft.AspNetCore.Mvc;
using Smart.Finances.DataAccess.Core.Common.Events;
using Smart.Finances.DataAccess.Event.Commands.UsuarioEvent.Commands;
using Smart.Finances.DataAccess.Event.ViewModels;

namespace Smart.Finances.DataAccess.Controllers.V1
{
    [Route("api/v1/usuario")]
    public class UsuarioController : ControllerBase
    {
        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Cadastrar(
            [FromServices] IRequestHandler<CadastrarUsuarioCommand, UsuarioViewModel> handler,
            [FromQuery] CadastrarUsuarioCommand command)
        {
            return Ok(handler.Handle(command));
        }

        [HttpPatch]
        [Route("atualizar/perfil")]
        public IActionResult AtualizarPerfil(
            [FromServices] IRequestHandler<EditarUsuarioCommand, UsuarioViewModel> handler,
            [FromQuery] EditarUsuarioCommand command)
        {
            return Ok(handler.Handle(command));
        }

        [HttpPatch]
        [Route("atualizar/senha")]
        public IActionResult AtualizarSenha(
            [FromServices] IRequestHandler<EditarUsuarioSenhaCommand, UsuarioViewModel> handler,
            [FromQuery] EditarUsuarioSenhaCommand command)
        {
            return Ok(handler.Handle(command));
        }
    }
}
