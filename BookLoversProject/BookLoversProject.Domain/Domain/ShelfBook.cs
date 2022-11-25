namespace BookLoversProject.Domain.Domain
{
    public class ShelfBook
    {
        public int BookId { get; set; }

        public Book Book { get; set; }

        public int ShelfId { get; set; }

        public Shelf Shelf { get; set; }
    }
}
