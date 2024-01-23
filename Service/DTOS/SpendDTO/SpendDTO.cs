using Domain.Entities.Enum_s;
using Domain.Entities;

namespace Service.DTOS.SpendDTO
{
    public class SpendDTO
    {
        public int? Id { get; set; }
        public SpendTypes? Type { get; set; }
        public Account? Account { get; set; }
        public DateTime? Date { get; set; }
        public double? Value { get; set; }
    }
}
