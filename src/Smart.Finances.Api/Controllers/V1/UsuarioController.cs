using Microsoft.AspNetCore.Mvc;
using Smart.Finances.Core.Common.Events;
using Smart.Finances.Application.Commands.UsuarioEvent.Commands;
using Smart.Finances.Application.ViewModels;

namespace Smart.Finances.Controllers.V1
{
    [Route("api/v1/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Cadastrar(
            [FromServices] IRequestHandler<CadastrarUsuarioCommand, UsuarioViewModel> handler,
            CadastrarUsuarioCommand command)
        {
            return Ok(handler.Handle(command));
        }

        [HttpPatch]
        [Route("atualizar/perfil")]
        public async Task<IActionResult> AtualizarPerfil(
            [FromServices] IRequestHandler<EditarUsuarioCommand, UsuarioViewModel> handler,
            [FromQuery] EditarUsuarioCommand command)
        {
            return Ok(await handler.Handle(command));
        }

        [HttpPatch]
        [Route("atualizar/senha")]
        public async Task<IActionResult> AtualizarSenha(
            [FromServices] IRequestHandler<EditarUsuarioSenhaCommand, UsuarioViewModel> handler,
            [FromQuery] EditarUsuarioSenhaCommand command)
        {
            return Ok(await handler.Handle(command));
        }
    }
}
