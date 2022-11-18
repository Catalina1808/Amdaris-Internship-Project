namespace ObserverPattern
{
    public class Reader : IFollower<Book>
    {
        public Reader(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public void Notify(Book book)
        {
            Console.WriteLine($@"Hi, I'm {Name} and I'm reading ""{book.Title}"".");
        }
    }
}
