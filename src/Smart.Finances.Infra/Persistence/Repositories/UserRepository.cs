using Microsoft.EntityFrameworkCore;
using Smart.Finances.Core.Entity;
using Smart.Finances.Core.Repositories;

namespace Smart.Finances.Infra.Persistence.Configurations
{
    public class UserRepository : IUserRepository
    {
        private readonly SqlServerDbContext _context;

        public UserRepository(SqlServerDbContext context)
        {
            _context = context;
        }

        public Task<User> GetByLogin(string email, string password)
        {
            return _context.User.SingleAsync(u => u.Email.Equals(email) && u.Password.Equals(password));
        }
    }
}
