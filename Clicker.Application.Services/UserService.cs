using Clicker.Domain.Core;
using Clicker.Domain.Interfaces;
using System.Collections.Generic;

namespace Clicker.Application.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userRepository.GetUserList();
        }

        public User GetUserById(int id)
        {
            return _userRepository.GetUser(id);
        }

        public void AddUser(User user)
        {
            // Здесь могут быть дополнительные бизнес-правила
            _userRepository.Create(user);
            _userRepository.Save();
        }

        public void UpdateUser(User user)
        {
            // Здесь могут быть дополнительные бизнес-правила
            _userRepository.Update(user);
            _userRepository.Save();
        }

        public void DeleteUser(int id)
        {
            _userRepository.Delete(id);
            _userRepository.Save();
        }
        public void Save()
        {
            _userRepository.Save();
        }
    }
}
