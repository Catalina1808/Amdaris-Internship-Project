using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Application.Queries.GetAuthorsQuery
{
    public class AuthorDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<BookAuthor> Books { get; set; }

        public ICollection<UserAuthor> Followers { get; set; }
    }
}
