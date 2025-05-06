using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballFieldManagement.Models;

namespace FootballFieldManagement.Repositories.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User GetById(int id);
        User GetByUsername(string username);
        void Add(User user);
        void Update(User user);
        void Delete(int id);
    }
}
