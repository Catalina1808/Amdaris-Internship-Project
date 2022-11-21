namespace BookLoversProject.Domain.Domain
{
    public class AccountAuthor : User, IAuthor
    {
        public string Name { get; set; }
        public ICollection<User> Followers { get; set; }

        //public AccountAuthor(int id, string email, string password, string name, List<User> followers) : base(id, email, password)
        //{
        //    Name = name;
        //    Followers = followers;
        //}

        public AccountAuthor(string name, string email, string password): base( email, password)
        {
            Name = name;
        }

    }
}
