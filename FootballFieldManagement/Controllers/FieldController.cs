using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballFieldManagement.Models;
using FootballFieldManagement.Services.Interfaces;

namespace FootballFieldManagement.Controllers
{
    public class FieldController
    {
        private readonly IFieldService _fieldService;

        public FieldController(IFieldService fieldService)
        {
            _fieldService = fieldService;
        }

        public IEnumerable<Field> GetAllFields()
        {
            return _fieldService.GetAllFields();
        }

        public Field GetFieldById(int id)
        {
            return _fieldService.GetFieldById(id);
        }

        public void AddField(Field field)
        {
            try
            {
                _fieldService.AddField(field);
                MessageBox.Show("Thêm Sân mới thành công!", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding field: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void UpdateField(Field field)
        {
            try
            {
                _fieldService.UpdateField(field);
                MessageBox.Show("Cập nhật Sân thành công!", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating field: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void DeleteField(int id)
        {
            try
            {
                _fieldService.DeleteField(id);
                MessageBox.Show("Xóa Sân thành công!", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting field: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
