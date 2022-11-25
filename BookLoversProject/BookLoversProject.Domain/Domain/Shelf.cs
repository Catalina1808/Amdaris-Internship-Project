using System.Collections;

namespace BookLoversProject.Domain.Domain
{
    public class Shelf : Entity, IEnumerable
    {
        public string Name { get; set; }
        public ICollection<ShelfBook> Books { get; set; }

        public Shelf(string name)
        {
            Name = name;
            Books = new List<ShelfBook>();
        }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)Books).GetEnumerator();
        }
    }
}
