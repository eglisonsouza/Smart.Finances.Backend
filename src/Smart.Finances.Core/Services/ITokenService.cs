using Smart.Finances.Core.Model.DTOs;

namespace Smart.Finances.Core.Services
{
    public interface ITokenService
    {
        TokenDTO GenerateToken(string email, string role, Guid id);
    }
}
