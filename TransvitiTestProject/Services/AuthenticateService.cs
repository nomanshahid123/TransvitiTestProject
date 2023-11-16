using TransvitiTestProject.IServices;
using TransvitiTestProject.Models;

namespace TransvitiTestProject.Services
{
    public class AuthenticateService : IAuthenticate
    {
        private List<User> _users = new List<User>
        {
        new User { Id = 1, FirstName = "Test", LastName = "User", Username = "test", Password = "test" }
        };

        public async Task<User> Authenticate(string username, string password)
        {
            var user = await Task.Run(() => _users.SingleOrDefault(x => x.Username == username && x.Password == password));
            return user;
        }
    }
}
