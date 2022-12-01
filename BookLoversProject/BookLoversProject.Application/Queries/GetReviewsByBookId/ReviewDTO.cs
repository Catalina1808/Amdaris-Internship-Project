namespace BookLoversProject.Application.Queries.GetReviewsByBookId
{
    public class ReviewDTO
    {
        public int Id { get; set; }

        public string Comment { get; set; }

        public DateTime Date { get; set; }
    }
}
