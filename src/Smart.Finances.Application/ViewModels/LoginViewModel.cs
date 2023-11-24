using Smart.Finances.Core.Model.DTOs;

namespace Smart.Finances.Application.ViewModels
{
    public class LoginViewModel
    {
        public string Name { get; }
        public string Email { get; }
        public TokenDTO Token { get; }

        public LoginViewModel(string name, string email, TokenDTO tokenDTO)
        {
            Name = name;
            Email = email;
            Token = tokenDTO;
        }

    }
}
