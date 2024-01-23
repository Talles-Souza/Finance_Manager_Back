using Domain.Entities.Enum_s;

namespace Domain.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public double Value { get; set; }
        public DateTime CreateAccount { get; set; }
        public DateTime UpdateAccount { get; set; }
        public User User { get; set; }
        public Spend Spend { get; set; }
        public AccountTypes Type { get; set; }
        public Account() { }

        public Account(int id, string number, double value, DateTime createAccount, DateTime updateAccount, User user, Spend spend, AccountTypes type)
        {
            Id = id;
            Number = number ?? throw new ArgumentNullException(nameof(number));
            Value = value;
            CreateAccount = createAccount;
            UpdateAccount = updateAccount;
            User = user ?? throw new ArgumentNullException(nameof(user));
            Spend = spend ?? throw new ArgumentNullException(nameof(spend));
            Type = type;
        }
    }
}
