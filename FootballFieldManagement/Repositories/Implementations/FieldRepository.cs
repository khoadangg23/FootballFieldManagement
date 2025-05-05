using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballFieldManagement.Models;
using FootballFieldManagement.Repositories.Interfaces;

namespace FootballFieldManagement.Repositories.Implementations
{
    public class FieldRepository : IFieldRepository
    {
        private readonly FootballFieldManagementDbContext _context;

        public FieldRepository(FootballFieldManagementDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Field> GetAll()
        {
            return _context.Fields.ToList();
        }

        public Field GetById(int id)
        {
            return _context.Fields.Find(id);
        }

        public void Add(Field field)
        {
            _context.Fields.Add(field);
            _context.SaveChanges();
        }

        public void Update(Field field)
        {
            _context.Fields.Update(field);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var field = _context.Fields.Find(id);
            if (field != null)
            {
                _context.Fields.Remove(field);
                _context.SaveChanges();
            }
        }
    }
}
