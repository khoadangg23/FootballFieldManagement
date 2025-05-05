using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballFieldManagement.Models;

namespace FootballFieldManagement.Repositories.Interfaces
{
    public interface IFieldRepository
    {
        IEnumerable<Field> GetAll();
        Field GetById(int id);
        void Add(Field field);
        void Update(Field field);
        void Delete(int id);
    }
}
