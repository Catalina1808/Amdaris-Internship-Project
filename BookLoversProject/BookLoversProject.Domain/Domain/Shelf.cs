using System.Collections;

namespace BookLoversProject.Domain.Domain
{
    public class Shelf : Entity, IEnumerable
    {
        public string Name { get; set; }
        public List<Book> Books { get; }

        //public Shelf(int id, string name)
        //{
        //    Id = id;
        //    Name = name;
        //    Books = new List<Book>();
        //}

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)Books).GetEnumerator();
        }
    }
}
