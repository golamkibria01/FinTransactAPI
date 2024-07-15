using FinTransactAPI.Data;
using FinTransactAPI.Model;

namespace FinTransactAPI.Services
{
    public class LoginService
    {
        private readonly FinTransactDbContext _context;

        public LoginService(FinTransactDbContext context)
        {
            _context = context;
        }
         
        public UserAuthentication IsUserAuthenticated(string username, string password)
        {
            var userAuthentication = _context.UserAuthentication
              .Where(u => u.Username == username && u.Password == password)
              .FirstOrDefault();

            return userAuthentication;
        }
    }
}
