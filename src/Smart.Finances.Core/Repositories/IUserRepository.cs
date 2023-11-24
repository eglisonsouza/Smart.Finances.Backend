using Smart.Finances.Core.Entity;

namespace Smart.Finances.Core.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByLogin(string email, string password);
    }
}
