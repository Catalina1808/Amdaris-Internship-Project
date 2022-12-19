using BookLoversProject.Application.DTO.BookDTOs;
using BookLoversProject.Application.DTO.UserDTOs;

namespace BookLoversProject.Application.DTO.AuthorDTOs
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
