namespace BookLoversProject.Application.DTO
{
    public class GenreGetDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<BookDTO> Books { get; set; }
    }
}
