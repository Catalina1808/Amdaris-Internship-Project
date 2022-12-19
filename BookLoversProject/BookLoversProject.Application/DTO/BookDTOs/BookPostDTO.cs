namespace BookLoversProject.Application.DTO.BookDTOs
{
    public class BookPostDTO
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public ICollection<int> AuthorsId { get; set; }

        public ICollection<int> GenresId { get; set; }
    }
}
