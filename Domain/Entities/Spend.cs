using Domain.Entities.Enum_s;

namespace Domain.Entities
{
    public class Spend
    {
        public int Id { get; set; }
        public SpendTypes Type { get; set;}
        public Account Account { get; set;}
        public DateTime Date { get; set; }
        public double Value { get; set; }
        public Spend() { }

        public Spend(int id, SpendTypes type, Account account, DateTime date, double value)
        {
            Id = id;
            Type = type;
            Account = account ?? throw new ArgumentNullException(nameof(account));
            Date = date;
            Value = value;
        }
    }
}
