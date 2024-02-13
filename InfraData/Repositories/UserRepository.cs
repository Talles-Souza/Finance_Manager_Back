using Domain.Entities;
using Domain.Repositories;
using InfraData.Context;
using Microsoft.EntityFrameworkCore;

namespace InfraData.Repositories
{
    public class UserRepository : IUserRepository
    {
        public readonly ContextDb _db;

        public UserRepository(ContextDb db)
        {
            _db = db;
        }
        public async Task<ICollection<User>> FindAll() => await _db.Users.Include(x => x.Account).ToListAsync();
        public async Task<User> FindById(int id) => await _db.Users.Include(x => x.Account).SingleOrDefaultAsync(x => x.Id == id);
        public async Task<User> Create(User body)
        {
            _db.Users.Add(body);
            await _db.SaveChangesAsync();
            return body;
        }
        public async Task<User> Update(User body)
        {
            _db.Users.Update(body);
            await _db.SaveChangesAsync();
            return body;
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var user = await _db.Users.Where(u => u.Id == id).FirstOrDefaultAsync();
                if (user == null) return false;
                _db.Users.Remove(user);
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
