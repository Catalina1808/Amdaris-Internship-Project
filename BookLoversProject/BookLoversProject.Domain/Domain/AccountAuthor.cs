namespace BookLoversProject.Domain.Domain
{
    public class AccountAuthor : User, IAuthor
    {
        public string Name { get; set; }
        public List<User> Followers { get; set; }

        //public AccountAuthor(int id, string email, string password, string name, List<User> followers) : base(id, email, password)
        //{
        //    Name = name;
        //    Followers = followers;
        //}

        public AccountAuthor(string email, string password, string name): base( email, password)
        {
            Name = name;
        }

    }
}
