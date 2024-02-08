using FusionStackBackEnd.Models;
namespace FusionStackBackEnd.Repository
{
    public class LoginRepositoryImpl : LoginRepository
    {
        private readonly AppDbContext _context;

        public LoginRepositoryImpl(AppDbContext context)
        {
            _context = context;
        }
        public User getUser(string email, string password)
        {
            Console.WriteLine(password);
            try
            {
                User user = _context.Users.FirstOrDefault(u => u.Email == email);
                if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.Password)) return null;

                return user;
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred while retrieving user credentials: {ex.Message}");
                return null;
            }

        }

        public User getUserByEmail(string email)
        {
            User user = _context.Users.FirstOrDefault(u => u.Email == email);
            return user;
        }
    }
}