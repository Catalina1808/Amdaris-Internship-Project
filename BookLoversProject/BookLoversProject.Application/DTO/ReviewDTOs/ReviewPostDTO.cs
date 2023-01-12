namespace BookLoversProject.Application.DTO.ReviewDTOs
{
    public class ReviewPostDTO
    {
        public string Comment { get; set; }

        public double Rating { get; set; }

        public int BookId { get; set; }

        public int UserId { get; set; }
    }
}
