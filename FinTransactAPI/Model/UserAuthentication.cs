using System.ComponentModel.DataAnnotations;

namespace FinTransactAPI.Model
{
    public class UserAuthentication
    {
        [Key]
        public int UserId { get; set; }

        [MaxLength(150)]
        public string Username { get; set; }

        [MaxLength(150)]
        public string Password { get; set; }

        public ICollection<Transaction> Transaction { get; set; }
    }
}
