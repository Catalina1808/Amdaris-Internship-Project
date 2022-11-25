namespace BookLoversProject.Domain.Domain
{
    public class Book : Entity, ICloneable
    {
  
        public string Title { get; set; }

        public string Description { get; set; }

        public ICollection<BookAuthor> Authors { get; set; }

        public ICollection<Review> Reviews { get; }

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
