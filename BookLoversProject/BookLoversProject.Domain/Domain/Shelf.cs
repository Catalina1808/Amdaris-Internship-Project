using System.Collections;

namespace BookLoversProject.Domain.Domain
{
    public class Shelf : Entity, IEnumerable
    {
        public string Name { get; set; }
        public ICollection<Book> Books { get; }

        public Shelf(string name)
        {
            Name = name;
            Books = new List<Book>();
        }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)Books).GetEnumerator();
        }
    }
}
