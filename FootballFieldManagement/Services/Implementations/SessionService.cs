using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballFieldManagement.Models;
using FootballFieldManagement.Services.Interfaces;

namespace FootballFieldManagement.Services.Implementations
{
    public class SessionService : ISessionService
    {
        private User _currentUser;
        public SessionService()
        {
            _currentUser = null;
        }
        public void SetCurrentUser(User user)
        {
            _currentUser = user;
        }
        public User GetCurrentUser()
        {
            return _currentUser;
        }
        public void ClearCurrentUser()
        {
            _currentUser = null;
        }
    }
}
