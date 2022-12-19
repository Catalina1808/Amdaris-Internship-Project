namespace BookLoversProject.Domain.Domain
{
    public class Shelf : Entity
    {
        public string Name { get; set; }

        public ICollection<ShelfBook> Books { get; set; }

        public int UserId { get; set; }
    }
}
