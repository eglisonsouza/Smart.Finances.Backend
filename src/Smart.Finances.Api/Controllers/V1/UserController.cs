using Microsoft.AspNetCore.Mvc;
using Smart.Finances.Application.Commands.UserEvent.Commands;
using Smart.Finances.Application.ViewModels;
using Smart.Finances.Core.Common.Events;

namespace Smart.Finances.Controllers.V1
{
    [Route("api/v1/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [Route("register")]
        public IActionResult Cadastrar(
            [FromServices] IRequestHandler<AddUserCommand, UserViewModel> handler,
            AddUserCommand command)
        {
            return Ok(handler.Handle(command));
        }

        [HttpPut]
        [Route("update/profile")]
        public async Task<IActionResult> UpdateProfile(
            [FromServices] IRequestHandler<UpdateUserCommand, UserViewModel> handler,
            UpdateUserCommand command)
        {
            return Ok(await handler.Handle(command));
        }

        [HttpPatch]
        [Route("update/password")]
        public async Task<IActionResult> UpdatePassword(
            [FromServices] IRequestHandler<UpdatePasswordCommand, UserViewModel> handler,
            UpdatePasswordCommand command)
        {
            return Ok(await handler.Handle(command));
        }
    }
}
