namespace BookLoversProject.Domain.Domain
{
    public class Review: Entity
    {
        public double Rating { get; set; }

        public string Comment { get; set; }

        public DateTime Date { get; set; }
    }
}
