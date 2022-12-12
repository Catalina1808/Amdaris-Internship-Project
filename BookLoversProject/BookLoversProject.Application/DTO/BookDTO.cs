using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Application.DTO
{
    public class BookDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public ICollection<BookAuthor> Authors { get; set; }

        public ICollection<Review> Reviews { get; set; }

        public ICollection<GenreBook> Genres { get; set; }

        public ICollection<ShelfBook> Shelves { get; set; }
    }
}
