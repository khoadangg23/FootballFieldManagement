using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballFieldManagement.Models;
using FootballFieldManagement.Repositories.Interfaces;
using FootballFieldManagement.Services.Interfaces;

namespace FootballFieldManagement.Services.Implementations
{
    internal class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public IEnumerable<User> GetAllUsers()
        {
            return _userRepository.GetAll();
        }
        public User GetUserById(int id)
        {
            return _userRepository.GetById(id);
        }
        public void AddUser(User user)
        {
            _userRepository.Add(user);
        }
        public void UpdateUser(User user)
        {
            _userRepository.Update(user);
        }
        public void DeleteUser(int id)
        {
            _userRepository.Delete(id);
        }
    }
}
