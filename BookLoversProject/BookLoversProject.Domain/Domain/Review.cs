namespace BookLoversProject.Domain.Domain
{
    public class Review: Entity
    {
        public string Comment { get; set; }

        public DateTime Date { get; set; }
    }
}
