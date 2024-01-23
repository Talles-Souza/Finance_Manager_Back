namespace Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public Account Account { get; set; }
        public User() { }
        public User(int id, string firstName, string email, string password, string fullName, Account account)
        {
            Id = id;
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Password = password ?? throw new ArgumentNullException(nameof(password));
            FullName = fullName ?? throw new ArgumentNullException(nameof(fullName));
            Account = account ?? throw new ArgumentNullException(nameof(account));
        }
    }
}
