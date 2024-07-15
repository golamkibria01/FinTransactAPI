using FinTransactAPI.Data;
using FinTransactAPI.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace FinTransactAPI.Repositories
{
    public class AccountInformationRepository:IAccountInformationRepository
    {
        private readonly FinTransactDbContext _context;

        public AccountInformationRepository(FinTransactDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AccountInformation>> GetAllAsync()
        {
            return await _context.AccountInformation.ToListAsync();
        }
        public async Task<AccountInformation> GetByIdAsync(int id)
        {
            return await _context.AccountInformation.FindAsync(id);
        }

        public async Task<AccountInformation> AddAsync(AccountInformation accountInformation)
        {
            _context.AccountInformation.Add(accountInformation);
            await _context.SaveChangesAsync();
            return accountInformation;
        }

        public async Task<AccountInformation> UpdateAsync(AccountInformation accountInformation)
        {
            _context.Entry(accountInformation).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return accountInformation;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var accountInformation = await _context.AccountInformation.FindAsync(id);
            if (accountInformation == null)
            {
                return false;
            }

            _context.AccountInformation.Remove(accountInformation);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
