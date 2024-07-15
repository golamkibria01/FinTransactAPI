using FinTransactAPI.Data;
using FinTransactAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace FinTransactAPI.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly FinTransactDbContext _context;

        public TransactionRepository(FinTransactDbContext context)
        {
            _context = context;
        }
         
        public async Task<IEnumerable<Transaction>> GetAllAsync()
        {
            return await _context.Transaction.ToListAsync();
        }
        public async Task<Transaction> GetByIdAsync(int id)
        {
            return await _context.Transaction.FindAsync(id);
        }

        public async Task<Transaction> AddAsync(Transaction transaction)
        {
            _context.Transaction.Add(transaction);
            await _context.SaveChangesAsync();
            return transaction;
        }

        public async Task<Transaction> UpdateAsync(Transaction transaction)
        {
            _context.Entry(transaction).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return transaction;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var transaction = await _context.Transaction.FindAsync(id);
            if (transaction == null)
            {
                return false;
            }

            _context.Transaction.Remove(transaction);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
