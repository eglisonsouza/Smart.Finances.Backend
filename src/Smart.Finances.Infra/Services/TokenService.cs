using Microsoft.IdentityModel.Tokens;
using Smart.Finances.Core.Model.DTOs;
using Smart.Finances.Core.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Smart.Finances.Infra.Services
{
    public class TokenService : ITokenService
    {
        private readonly DateTime _expiresInDays;

        public TokenService()
        {
            _expiresInDays = DateTime.Now.AddDays(7);
        }

        public TokenDTO GenerateToken(string email, string role)
        {
            return new TokenDTO()
            {
                ExpiresInDays = _expiresInDays,
                Token = new JwtSecurityTokenHandler().WriteToken(SetupToken(email, role))
            };
        }

        private JwtSecurityToken SetupToken(string email, string role)
        {
            return new JwtSecurityToken(
                               issuer: "Smart.Finances",
                               audience: "Smart.Finances",
                               claims: GetClaims(email, role),
                               expires: _expiresInDays,
                               signingCredentials: GetCredentials()
            );
        }

        private static SigningCredentials GetCredentials()
        {
            return new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Esta e Minha Senha Secreta Para Proteger Meus Tokens!")),
                    SecurityAlgorithms.HmacSha256Signature);
        }

        private static IEnumerable<Claim> GetClaims(string email, string role)
        {
            return new List<Claim>
            {
                new(ClaimTypes.Email, email),
                new(ClaimTypes.Role, role)
            };
        }
    }
}
