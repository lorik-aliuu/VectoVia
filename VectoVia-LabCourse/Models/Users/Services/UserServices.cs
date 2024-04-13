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
            };
            _context.Users.Add(_user);
            _context.SaveChanges();
        }
    }
}
