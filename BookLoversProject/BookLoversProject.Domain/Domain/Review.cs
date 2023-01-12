namespace BookLoversProject.Domain.Domain
{
    public class Review: Entity
    {
        public string Comment { get; set; }

        public DateTime Date { get; set; }

        public double Rating { get; set; }

        public int BookId { get; set; }

        public int UserId { get; set; }
    }
}
