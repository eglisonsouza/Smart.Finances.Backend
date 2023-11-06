namespace Smart.Finances.DataAccess.Core.Services
{
    public interface IAuthService
    {
        public string ComputarSha256Hash(string password);
    }
}
