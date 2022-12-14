namespace BookLoversProject.Application.DTO
{
    public class AuthorGetDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<BookDTO> Books { get; set; }

        public ICollection<UserDTO> Followers { get; set; }
    }
}
