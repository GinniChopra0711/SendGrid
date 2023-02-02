using Web_Security_Lab_Day3.Data;
using Web_Security_Lab_Day3.ViewModels;

namespace Web_Security_Lab_Day3.Repositories
{
    public class UserRepo
    {

        private readonly ApplicationDbContext _context;

        public UserRepo(ApplicationDbContext context)
        {
            _context = context;
        }


        public IEnumerable<UserVM> All()
        {
            //List<UserVM> userList = new List<UserVM>();

            IEnumerable<UserVM> users = _context.Users.Select(u => new UserVM() { Email = u.Email });

            return users;

        }
    }
}
