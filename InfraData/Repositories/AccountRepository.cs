using Domain.Entities;
using Domain.Repositories;
using InfraData.Context;
using Microsoft.EntityFrameworkCore;

namespace InfraData.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        public readonly ContextDb _db;

        public AccountRepository(ContextDb db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public async Task<ICollection<Account>> FindAll() => await _db.Accounts.Include(x => x.User).Include(x => x.Spends).ToListAsync();

        public async Task<Account> FindById(int id) => await _db.Accounts.Include(x => x.User).Include(x=> x.Spends).SingleOrDefaultAsync(x => x.Id == id);
        public async Task<Account> Create(Account body)
        {
            _db.Accounts.Add(body);
            await _db.SaveChangesAsync();
            return body;
        }
        public async Task<Account> Update(Account body)
        {
            _db.Accounts.Update(body);
            await _db.SaveChangesAsync();
            return body;
        }
        public async Task<bool> Delete(int id)
        {
            try
            {
                var account = await _db.Accounts.Where(u => u.Id == id).FirstOrDefaultAsync();
                if (account == null) return false;
                _db.Accounts.Remove(account);
                await _db.SaveChangesAsync();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
