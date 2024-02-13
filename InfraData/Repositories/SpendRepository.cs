using Domain.Entities;
using Domain.Repositories;
using InfraData.Context;
using Microsoft.EntityFrameworkCore;

namespace InfraData.Repositories
{
    public class SpendRepository : ISpendRepository
    {
        public readonly ContextDb _db;

        public SpendRepository(ContextDb db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public async Task<ICollection<Spend>> FindAll() => await _db.Spends.Include(x=> x.Account).ToListAsync();

        public async Task<Spend> FindById(int id) => await _db.Spends.Include(x => x.Account).SingleOrDefaultAsync(x => x.Id == id);
        public async Task<Spend> Create(Spend body)
        {
            _db.Spends.Add(body);
            await _db.SaveChangesAsync();
            return body;
        }
        public async Task<Spend> Update(Spend body)
        {
            _db.Spends.Update(body);
            await _db.SaveChangesAsync();
            return body;
        }
        public async Task<bool> Delete(int id)
        {
            try
            {
                var spend = await _db.Spends.Where(u => u.Id == id).FirstOrDefaultAsync();
                if (spend == null) return false;
                _db.Spends.Remove(spend);
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
