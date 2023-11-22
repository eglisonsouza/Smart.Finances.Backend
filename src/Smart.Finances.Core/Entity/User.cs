namespace Smart.Finances.Core.Entity
{
    public class User : BaseEntity
    {
        public string Name { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }
        public IList<Expense>? Expenses { get; private set; }

        public User(string name, string password, string email) : base()
        {
            Name = name;
            Password = password;
            Email = email;
        }

        public void UpdateProfile(string name, string email)
        {
            Update();
            Name = name;
            Email = email;
        }

        public void UpdatePassword(string password)
        {
            Update();
            Password = password;
        }
    }
}
