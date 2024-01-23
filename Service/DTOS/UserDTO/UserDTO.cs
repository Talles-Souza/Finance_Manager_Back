using Domain.Entities;

namespace Service.DTOS.UserDTO
{
    public class UserDTO
    {
        public int? Id { get; set; }
        public string? FirstName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? FullName { get; set; }
        public Account? Account { get; set; }
    }
}
