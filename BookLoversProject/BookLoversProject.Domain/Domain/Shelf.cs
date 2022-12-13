using System.Collections;

namespace BookLoversProject.Domain.Domain
{
    public class Shelf : Entity
    {
        public string Name { get; set; }

        public ICollection<ShelfBook> Books { get; set; }
    }
}
