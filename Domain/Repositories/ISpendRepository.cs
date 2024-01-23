using Domain.Entities;

namespace Domain.Repositories
{
    public interface ISpendRepository
    {
        Task<ICollection<Spend>> FindAll();
        Task<Spend> FindById(int id);
        Task<Spend> Create(Spend body);
        Task<Spend> Update(Spend body);
        Task<bool> Delete(int id);
    }
}
