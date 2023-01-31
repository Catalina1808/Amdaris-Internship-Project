using System.ComponentModel.DataAnnotations;

namespace BookLoversProject.Domain.Domain
{
    public class Author : Entity
    {
        [MaxLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public ICollection<BookAuthor> Books { get; set; }

        public ICollection<UserAuthor> Followers { get; set; }
    }
}
