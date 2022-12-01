using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Application.Queries.GetGenresQuery
{
    public class GenreDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<GenreBook> Books { get; set; }
    }
}
