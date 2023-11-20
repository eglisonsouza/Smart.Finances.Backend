namespace Smart.Finances.Core.Services
{
    public interface IAuthService
    {
        public string ComputarSha256Hash(string password);
    }
}
