using ObserverPattern;

namespace Assignment12
{
    public class Author : Publisher<Book>
    {
        public Author(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}