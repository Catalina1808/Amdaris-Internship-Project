using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Application.DTO
{
    public class BookGetDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public ICollection<AuthorDTO> Authors { get; set; }

        public ICollection<Review> Reviews { get; set; }

        public ICollection<GenreDTO> Genres { get; set; }

        public ICollection<ShelfDTO> Shelves { get; set; }
    }
}
