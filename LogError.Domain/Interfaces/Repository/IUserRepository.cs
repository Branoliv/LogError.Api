using LogError.Domain.Entities;
using System.Threading.Tasks;

namespace LogError.Domain.Interfaces.Repository
{
    public interface IUserRepository
    {
        Task<User> SaveAsync(User user);
        Task<User> GetAsync(string email);
        Task<User> GetAsync(string email, string password);
    }
}
