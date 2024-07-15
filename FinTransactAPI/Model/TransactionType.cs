using System.ComponentModel.DataAnnotations;

namespace FinTransactAPI.Model
{
    public class TransactionType
    {
        [Key]
        public int TransactionTypeId { get; set; }

        [MaxLength(100)]
        public string TransactionTypeName { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsDeleted { get; set; }

        public ICollection<Transaction> Transaction { get; set; }
    }
}
