using LogError.Domain.Entities;
using LogError.Domain.Interfaces.Repository;
using LogError.Infra.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace LogError.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly LogErrorContext _context;

        public UserRepository(LogErrorContext context)
        {
            _context = context;
        }

        public Task<User> GetAsync(string email)
        {
            var user = _context.Users
                .Where(x => x.Email.Equals(email))
                .FirstOrDefault();

            return Task.FromResult(user);
        }

        public Task<User> GetAsync(string email, string password)
        {
            var user = _context.Users
                .Where(x => x.Email.Equals(email) && x.Password.Equals(password))
                .FirstOrDefault();

            return Task.FromResult(user);
        }

        public async Task<User> SaveAsync(User user)
        {
            var _user = await _context.Users.AddAsync(user);

            if (_user.State.Equals(EntityState.Added))
                _context.SaveChangesAsync().Wait();

            return _user.Entity;
        }
    }
}
