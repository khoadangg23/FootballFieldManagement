using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballFieldManagement.Models;

namespace FootballFieldManagement.Services.Interfaces
{
    public interface ISessionService
    {
        void SetCurrentUser(User user);
        User GetCurrentUser();
        void ClearCurrentUser();

    }
}
