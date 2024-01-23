using Domain.Entities;

namespace Service.DTOS.UserDTO
{
    public class UserCreateDTO
    {     
        public string? FirstName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? FullName { get; set; }      
    }
}
