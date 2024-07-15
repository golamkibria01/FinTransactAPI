using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FinTransactAPI.Model
{
    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long TransactionId { get; set; }

        public DateTime? TransactionDate { get; set; }

        public decimal? TransactionAmount { get; set; }

        public long? AccountInformationId { get; set; }

        public int? TransactionTypeId { get; set; }

        public int UserId {  get; set; }

        public bool? IsActive { get; set; }

        public bool? IsDeleted { get; set; }
         
        public UserAuthentication UserAuthentication { get; set; }

        public AccountInformation AccountInformation { get; set; }

        public TransactionType TransactionType { get; set; }
    }
}
 