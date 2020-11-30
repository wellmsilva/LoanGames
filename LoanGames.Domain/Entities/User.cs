namespace LoanGames.Domain.Entities
{
    public class User : Entity
    {
        protected User() { }

        public User(string name, string userName, string password)
        {
            Name = name;
            UserName = userName;
            Password = password;
            Active = true;
        }

        public string Name { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public bool Active { get; private set; }
    }
}
