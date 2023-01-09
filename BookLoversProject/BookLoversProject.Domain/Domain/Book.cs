using System.ComponentModel.DataAnnotations;

namespace BookLoversProject.Domain.Domain
{
    public class Book : Entity, ICloneable
    {
        [MaxLength(200)]
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public double Rating { get; set; }

        public ICollection<BookAuthor> Authors { get; set; }

        public ICollection<Review> Reviews { get; set; }

        public ICollection<GenreBook> Genres { get; set; }

        public ICollection<ShelfBook> Shelves { get; set; }

        public object Clone()
        {
            Book clone = new Book
            {
                Id = Id,
                Title = Title,
                Description = Description,
                Authors = Authors,
                Genres = Genres
            };
            return clone;
        }
    }
}
