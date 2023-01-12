namespace BookLoversProject.Application.DTO.ReviewDTOs
{
    public class ReviewGetDTO
    {
        public int Id { get; set; }

        public string Comment { get; set; }

        public double Rating { get; set; }

        public DateTime Date { get; set; }

        public int BookId { get; set; }

        public int UserId { get; set; }
    }
}
