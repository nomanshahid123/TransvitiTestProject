using TransvitiTestProject.Models;

namespace TransvitiTestProject.IServices
{
    public interface IAuthenticate
    {
        Task<User> Authenticate(string username, string password);
    }
}
