using System.ComponentModel.DataAnnotations;

namespace FinTransactAPI.Model
{
    public class UserLogin
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
