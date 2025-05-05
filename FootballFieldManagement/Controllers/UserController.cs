using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballFieldManagement.Models;
using FootballFieldManagement.Services.Interfaces;

namespace FootballFieldManagement.Controllers
{
    public class UserController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userService.GetAllUsers();
        }

        public User GetUserById(int id)
        {
            return _userService.GetUserById(id);
        }

        public void AddUser(User user)
        {
            _userService.AddUser(user);
        }

        public void UpdateUser(User user)
        {
            _userService.UpdateUser(user);
        }
    }
}
