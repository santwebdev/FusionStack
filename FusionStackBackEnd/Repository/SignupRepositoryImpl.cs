using FusionStackBackEnd.Models;


namespace FusionStackBackEnd.Repository
{
    public class SignupRepositoryImpl

    {
        private readonly AppDbContext context;

        public SignupRepositoryImpl(AppDbContext context)
        {
            this.context = context;
        }

        public void AddUser(User user)
        {
            user.Password= EncryptPassword(user.Password);
            context.Users.Add(user);
                context.SaveChanges();
               
            
        }

        private string EncryptPassword(string password)
        {
            
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

    }
}
