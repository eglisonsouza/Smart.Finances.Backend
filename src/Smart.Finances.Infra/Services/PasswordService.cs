using Smart.Finances.Core.Services;
using System.Security.Cryptography;
using System.Text;

namespace Smart.Finances.Infra.Services
{
    public class PasswordService : IPasswordService
    {
        public string ComputeSha256Hash(string password)
        {
            return string.Join(string.Empty, CreateHash(password).Select(h => h.ToString("x2")));
        }

        private static byte[] CreateHash(string source)
        {
            return SHA256.HashData(Encoding.UTF8.GetBytes(source));
        }
    }
}
