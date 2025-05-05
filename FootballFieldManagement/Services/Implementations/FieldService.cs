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
    public class FieldService : IFieldService
    {
        private readonly IFieldRepository _fieldRepository;

        public FieldService(IFieldRepository fieldRepository)
        {
            _fieldRepository = fieldRepository;
        }

        public IEnumerable<Field> GetAllFields()
        {
            return _fieldRepository.GetAll();
        }

        public Field GetFieldById(int id)
        {
            return _fieldRepository.GetById(id);
        }

        public void AddField(Field field)
        {
            _fieldRepository.Add(field);
        }

        public void UpdateField(Field field)
        {
            _fieldRepository.Update(field);
        }

        public void DeleteField(int id)
        {
            _fieldRepository.Delete(id);
        }
    }
}
