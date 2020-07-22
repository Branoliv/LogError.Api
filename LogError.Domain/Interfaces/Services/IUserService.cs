using LogError.Domain.Entities;

namespace LogError.Domain.Interfaces.Services
{
    public interface IUserService : IServiceBase
    {
        User Save(User user);
        User GetUser(string email);
        User Auth(string email, string password);
    }
}
