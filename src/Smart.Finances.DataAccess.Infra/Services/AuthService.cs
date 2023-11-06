using Smart.Finances.DataAccess.Core.Services;
using System.Security.Cryptography;
using System.Text;

namespace Smart.Finances.DataAccess.Infra.Services
{
    public class AuthService : IAuthService
    {
        public string ComputarSha256Hash(string password)
        {
            return string.Join(string.Empty, CreateHash(password).Select(h => h.ToString("x2")));
        }

        private static byte[] CreateHash(string source)
        {
            return SHA256.HashData(Encoding.UTF8.GetBytes(source));
        }
    }
}
