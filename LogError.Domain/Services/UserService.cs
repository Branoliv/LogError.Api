using LogError.Domain.Entities;
using LogError.Domain.Interfaces.Repository;
using LogError.Domain.Interfaces.Services;

namespace LogError.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User Auth(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                return null;
            }

            var user = _userRepository.GetAsync(email,password).Result;

            if (user == null)
            {
                return null;
            }

            return user;
        }

        public User GetUser(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return null;
            }

            var user = _userRepository.GetAsync(email).Result;

            return user;
        }

        public User Save(User user)
        {
            if (user == null)
            {
                return null;
            }

            var _user = new User(user.Name, user.Email, user.Password);

            var response = _userRepository.SaveAsync(_user).Result;

            return response;
        }
    }
}
