namespace Smart.Finances.Core.Services
{
    public interface IAuthService
    {
        public string ComputeSha256Hash(string password);
    }
}
