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

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetUserList();
        }

        public User? GetById(int id)
        {
            return _userRepository.GetUser(id);
        }

        public void Add(User user)
        {
            // Здесь могут быть дополнительные бизнес-правила
            _userRepository.Create(user);
            Save();
        }

        public void Update(User user)
        {
            _userRepository.Update(user);
            Save();
        }

        public void Delete(int id)
        {
            _userRepository.Delete(id);
            Save();
        }
        public void Save()
        {
            _userRepository.Save();
        }
    }
}
