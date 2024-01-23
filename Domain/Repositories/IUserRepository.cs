using Domain.Entities;

namespace Domain.Repositories
{
    public interface IUserRepository
    {
        Task<ICollection<User>> FindAll();
        Task<User> FindById(int id);
        Task<User> Create(User body);
        Task<User> Update(User body);
        Task<bool> Delete(int id);
    }
}
