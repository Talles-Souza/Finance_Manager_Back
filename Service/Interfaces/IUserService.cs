using Service.DTOS.UserDTO;
using Service.Exceptions;

namespace Service.Interfaces
{
    public interface IUserService
    {
        Task<ExceptionManager<ICollection<UserDTO>>> FindAll();
        Task<ExceptionManager<UserDTO>> FindById(int id);
        Task<ExceptionManager<UserDTO>> Create(UserCreateDTO user);
        Task<ExceptionManager<UserDTO>> Update(UserDTO user);
        Task<ExceptionManager> Delete(int id);
    }
}
