using VectoVia.Models.Users;
using VectoVia.Models.Users.Model;
using VectoVia_LabCourse.Views;

namespace VectoVia_LabCourse.Models.Users.Services
{
    public class UserServices
    {
        private UsersDbContext _context;
        public UserServices(UsersDbContext context)
        {
            _context = context;
        }

        public void AddUser(UserVM user)
        {
            var _user = new User()
            {
                Emri = user.Emri,
                Mbiemri = user.Mbiemri,
                Username = user.Username,
                Email = user.Email,
                Password = user.Password,
                Role = user.Role,
            };
            _context.Users.Add(_user);
            _context.SaveChanges();
        }
    
        public List<User> GetUsers()
        {
            var allUsers = _context.Users.ToList();
            return allUsers;
        }
        public User GetUsersByID(int UserID)
        {
            return _context.Users.FirstOrDefault(n => n.ID == UserID);
        }
    }
}
