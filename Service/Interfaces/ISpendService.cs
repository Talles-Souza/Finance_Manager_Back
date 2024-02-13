using Service.DTOS.SpendDTO;
using Service.Exceptions;

namespace Service.Interfaces
{
    public interface ISpendService
    {
        Task<ExceptionManager<ICollection<SpendDTO>>> FindAll();
        Task<ExceptionManager<SpendDTO>> FindById(int id);
        Task<ExceptionManager<SpendDTO>> Create(SpendDTO spend);
        Task<ExceptionManager<SpendDTO>> Update(SpendDTO spend);
        Task<ExceptionManager> Delete(int id);
    }
}
