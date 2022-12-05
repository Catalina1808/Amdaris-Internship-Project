using System.ComponentModel.DataAnnotations;

namespace BookLoversProject.Domain.Domain
{
    [Serializable]
    public class Genre: Entity
    {
        [MaxLength (50)]
        [Required]
        public string Name { get; set; }

        public ICollection<GenreBook> Books { get; set; }
    }
}