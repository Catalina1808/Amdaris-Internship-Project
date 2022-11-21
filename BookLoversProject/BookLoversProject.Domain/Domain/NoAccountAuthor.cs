namespace BookLoversProject.Domain.Domain
{
    public class NoAccountAuthor : Entity, IAuthor
    {
        public string Name { get; set; }
        public ICollection<User> Followers { get; set; }

        public NoAccountAuthor(string name)
        {
            Name = name;
        }

    }
}
