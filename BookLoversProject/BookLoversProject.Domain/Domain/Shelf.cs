using System.Collections;

namespace BookLoversProject.Domain.Domain
{
    public class Shelf : Entity, IEnumerable
    {
        public string Name { get; set; }

        public ICollection<ShelfBook> Books { get; set; }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)Books).GetEnumerator();
        }
    }
}
