using Domain.Repositories;
using Service.DTOS.UserDTO;
using Service.Exceptions;

namespace Service.Utils
{
    public class UserUtils
    {
        public bool ValidateAndFindExistingUser(UserCreateDTO user)
        {
            if (user.Email == null) return true;
            if (user.FirstName == null) return true;
            if (user.FullName == null) return true;
            if (user.Password == null) return true; 
            return false;
        }     
        public async Task<ExceptionManager<UserDTO>> ReturnMessageError(UserCreateDTO user)
        {          
            if (user.Email == null) return ExceptionManager.BadRequest<UserDTO>("Name is null");
            if (user.Password == null) return ExceptionManager.BadRequest<UserDTO>("Password is null");
            if (user.FullName == null) return ExceptionManager.BadRequest<UserDTO>("FullName is null");
            if (user.FirstName == null) return ExceptionManager.BadRequest<UserDTO>("FirstName is null");
            return ExceptionManager.BadRequest<UserDTO>("Not problem");
        }        
    }
}
