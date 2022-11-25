namespace BookLoversProject.Domain.Domain
{
    public class ReaderAuthor
    {
        public int ReaderId { get; set; }

        public Reader Reader { get; set; }

        public int AuthorId { get; set; }

        public Author Author { get; set; }
    }
}
