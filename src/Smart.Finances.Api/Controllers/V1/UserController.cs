using Microsoft.AspNetCore.Mvc;
using Smart.Finances.Core.Common.Events;
using Smart.Finances.Application.Commands.UserEvent.Commands;
using Smart.Finances.Application.ViewModels;

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
            [FromQuery] UpdateUserCommand command)
        {
            return Ok(await handler.Handle(command));
        }

        [HttpPatch]
        [Route("update/password")]
        public async Task<IActionResult> UpdatePassword(
            [FromServices] IRequestHandler<UpdatePasswordCommand, UserViewModel> handler,
            [FromQuery] UpdatePasswordCommand command)
        {
            return Ok(await handler.Handle(command));
        }
    }
}
