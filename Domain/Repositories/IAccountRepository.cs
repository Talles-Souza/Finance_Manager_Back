using Domain.Entities;

namespace Domain.Repositories
{
    public interface IAccountRepository
    {
        Task<ICollection<Account>> FindAll();
        Task<Account> FindById(int id);
        Task<Account> Create(Account body);
        Task<Account> Update(Account body);
        Task<bool> Delete(int id);
    }
}
