using Domain.Entities.Enum_s;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public double Value { get; set; }
        public DateTime CreateAccount { get; set; }
        public DateTime UpdateAccount { get; set; }
        [JsonIgnore]
        public User User { get; set; }
        public ICollection<Spend> Spends { get; set; }
        public AccountTypes Type { get; set; }
        public Account() { }

        public Account(int id, string number, double value, DateTime createAccount, DateTime updateAccount, User user, ICollection<Spend> spends, AccountTypes type)
        {
            Id = id;
            Number = number ?? throw new ArgumentNullException(nameof(number));
            Value = value;
            CreateAccount = createAccount;
            UpdateAccount = updateAccount;
            User = user ?? throw new ArgumentNullException(nameof(user));
            Spends = spends ?? throw new ArgumentNullException(nameof(spends));
            Type = type;
        }
    }
}
