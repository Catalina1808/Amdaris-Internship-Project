namespace BookLoversProject.Domain.Domain
{
    public class NoAccountAuthor : Entity, IAuthor
    {
        public string Name { get; set; }
        public List<User> Followers { get; set; }

        //public NoAccountAuthor(int id, string name, List<User> followers)
        //{
        //    Id = id;
        //    Name = name;
        //    Followers = followers;
        //}

        //public NoAccountAuthor(int id, string name)
        //{
        //    Id = id;
        //    Name = name;
        //    Followers = new List<User>();
        //}

    }
}
