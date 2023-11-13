using Microsoft.Extensions.Configuration;
using ToDoList.Data.Repository;
using ToDoList.Services.Models;

namespace ToDoList.Services.Services
{
    public class UserService : IUserServices
    {
        private readonly IUserRepository userRepository;
        private readonly IConfiguration configuration;

        public UserService(IUserRepository userRepository, IConfiguration configuration)
        {
            this.userRepository = userRepository;
            this.configuration = configuration;
        }

        public string Login(string username, string password)
        {
            var user = userRepository.GetByUsername(username);

            if (user == null)
            {
                return "User not found";
            }
            if (password != user.Password)
            {
                return "Password Incorrect";
            }

            return "Log in successful";
        }

        public RegisterResult Register(string username, string password)
        {
            RegisterResult result = Validate(username, password);

            if (result.IsSuccess)
            {
                var user = new Data.Entities.User
                {
                    UserName = username,
                    Password = password
                };
                userRepository.Create(user);
            }
            return result;
        }


        private static RegisterResult Validate(string username, string password)
        {
            if (string.IsNullOrEmpty(username))
            {
                return new RegisterResult
                {
                    Message = "Username is required! "
                };

            }

            if (string.IsNullOrEmpty(password))
            {
                return new RegisterResult
                {
                    Message="Password is required!"
                };
            }

            return new RegisterResult();
        }
    }
}
