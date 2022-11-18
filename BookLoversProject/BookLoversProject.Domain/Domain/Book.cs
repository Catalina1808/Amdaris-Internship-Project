using System.ComponentModel.DataAnnotations;

namespace BookLoversProject.Domain.Domain
{
    public class Book : Entity, ICloneable
    {
        public string Title { get; set; }

        public string Description { get; set; } = string.Empty;

        public List<IAuthor> AuthorList { get; set; }

        public ICollection<User> ReviewList { get; set; }

        public ICollection<Genre> GenreList { get; set; }

        public object Clone()
        {
            Book clone = new Book
            {
                Id = Id,
                Title = Title,
                Description = Description,
                AuthorList = AuthorList,
                GenreList = GenreList
            };
            return clone;
        }
    }
}
