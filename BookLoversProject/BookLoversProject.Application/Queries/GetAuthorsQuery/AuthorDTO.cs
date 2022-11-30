using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Application.Queries.GetAuthorsQuery
{
    public class AuthorDTO
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<BookAuthor> Books { get; set; }

        public ICollection<ReaderAuthor> Followers { get; set; }
    }
}
