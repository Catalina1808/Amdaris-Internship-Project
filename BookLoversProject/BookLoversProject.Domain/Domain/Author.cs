namespace BookLoversProject.Domain.Domain
{
    public class Author : Entity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<BookAuthor> Books { get; set; }

        public ICollection<UserAuthor> Followers { get; set; }
    }
}
