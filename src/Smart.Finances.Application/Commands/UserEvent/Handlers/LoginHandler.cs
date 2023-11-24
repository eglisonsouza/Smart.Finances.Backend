using Smart.Finances.Application.Commands.UserEvent.Commands;
using Smart.Finances.Application.ViewModels;
using Smart.Finances.Core.Common.Events;
using Smart.Finances.Core.Enums;
using Smart.Finances.Core.Repositories;
using Smart.Finances.Core.Services;
using Smart.Finances.Core.Utils.MessageError;

namespace Smart.Finances.Application.Commands.UserEvent.Handlers
{
    public class LoginHandler : IRequestHandler<LoginCommand, LoginViewModel>
    {
        private readonly ITokenService _tokenService;
        private readonly IPasswordService _passwordService;
        private readonly IUserRepository _userRepository;

        public LoginHandler(ITokenService tokenService, IPasswordService passwordService, IUserRepository userRepository)
        {
            _tokenService = tokenService;
            _passwordService = passwordService;
            _userRepository = userRepository;
        }

        public async Task<LoginViewModel> Handle(LoginCommand request)
        {
            var user = await _userRepository.GetByLogin(request.Email!, _passwordService.ComputeSha256Hash(request.Password!));

            return user is null
                ? throw new Exception(MessageError.LoginInvalid)
                : new LoginViewModel(user.Name, user.Email, _tokenService.GenerateToken(user.Email, RoleUserEnums.UserApp.ToString()));
        }
    }
}
