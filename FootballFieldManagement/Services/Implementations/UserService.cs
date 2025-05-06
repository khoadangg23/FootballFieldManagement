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

        public User GetUserByUsername(string username)
        {
            return _userRepository.GetByUsername(username);
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

        public bool ValidateUser(string username, string password)
        {
            try
            {
                // 1. Lấy người dùng từ DB dựa vào tên đăng nhập
                var user = _userRepository.GetByUsername(username); // Sử dụng phương thức từ Repository

                // 2. Kiểm tra xem người dùng có tồn tại không
                if (user == null)
                {
                    return false; // Không tìm thấy người dùng
                }

                //bool isPasswordValid = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);
                bool isPasswordValid = password == user.PasswordHash ? true : false;

                return isPasswordValid; // Trả về true nếu mật khẩu khớp, false nếu không khớp
            }
            catch (Exception ex)
            {
                // Ghi log lỗi nếu có vấn đề khi truy vấn DB hoặc xử lý
                Console.WriteLine("Lỗi khi ValidateUser: " + ex.Message);
                // Trả về false trong trường hợp có lỗi
                return false;
            }
        }
    }
}
