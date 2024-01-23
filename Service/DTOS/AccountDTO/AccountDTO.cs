using Domain.Entities.Enum_s;
using Domain.Entities;

namespace Service.DTOS.AccountDTO
{
    public class AccountDTO
    {
        public int? Id { get; set; }
        public string? Number { get; set; }
        public double? Value { get; set; }
        public DateTime CreateAccount { get; set; }
        public DateTime UpdateAccount { get; set; }
        public User? User { get; set; }
        public Spend? Spend { get; set; }
        public AccountTypes Type { get; set; }
    }
}
