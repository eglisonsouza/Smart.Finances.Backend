namespace Smart.Finances.Core.Services
{
    public interface IPasswordService
    {
        public string ComputeSha256Hash(string password);
    }
}
