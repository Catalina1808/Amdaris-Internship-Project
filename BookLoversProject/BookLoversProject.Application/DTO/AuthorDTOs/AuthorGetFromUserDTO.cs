using BookLoversProject.Application.DTO.BookDTOs;

namespace BookLoversProject.Application.DTO.AuthorDTOs
{
    public class AuthorGetFromUserDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public ICollection<BookDTO> Books { get; set; }
    }
}
