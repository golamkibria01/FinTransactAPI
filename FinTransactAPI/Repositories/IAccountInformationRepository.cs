using FinTransactAPI.Model;

namespace FinTransactAPI.Repositories
{
    public interface IAccountInformationRepository
    {
        Task<IEnumerable<AccountInformation>> GetAllAsync();
        Task<AccountInformation> GetByIdAsync(int id);
        Task<AccountInformation> AddAsync(AccountInformation accountInformation);
        Task<AccountInformation> UpdateAsync(AccountInformation accountInformation);
        Task<bool> DeleteAsync(int id);
    }
}
 