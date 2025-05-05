using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballFieldManagement.Models;

namespace FootballFieldManagement.Services.Interfaces
{
    public interface IFieldService
    {
        IEnumerable<Field> GetAllFields();
        Field GetFieldById(int id);
        void AddField(Field field);
        void UpdateField(Field field);
        void DeleteField(int id);
    }
}
