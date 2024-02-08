using FusionStackBackEnd.Models;

namespace FusionStackBackEnd.Repository
{
    public interface LoginRepository

    {
        public User getUser(String email,string password);
        public User getUserByEmail(String email);
    }
}
