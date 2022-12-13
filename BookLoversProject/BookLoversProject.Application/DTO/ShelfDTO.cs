using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Application.DTO
{
    public class ShelfDTO
    {
        public string Name { get; set; }

        public ICollection<ShelfBook> Books { get; set; }
    }
}
