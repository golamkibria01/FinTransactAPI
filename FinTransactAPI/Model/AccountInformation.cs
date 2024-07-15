using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
 
namespace FinTransactAPI.Model
{
    public class AccountInformation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long AccountInformationId { get; set; }

        [MaxLength(150)]
        public string AccountName { get; set; }

        [MaxLength(50)]
        public string AccountNumber { get; set; }

        [MaxLength(150)]
        public string AccountHolderName { get; set; }

        [MaxLength(20)]
        public string ContactNumber { get; set; }

        [EmailAddress]
        [MaxLength(320)]
        public string Email { get; set; }

        [MaxLength(500)]
        public string HomeAddress { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsDeleted { get; set; }

        public ICollection<Transaction> Transaction { get; set; }
    }
}
