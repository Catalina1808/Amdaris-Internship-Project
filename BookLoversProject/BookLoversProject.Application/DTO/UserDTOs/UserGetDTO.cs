using BookLoversProject.Application.DTO.AuthorDTOs;
using BookLoversProject.Application.DTO.ShelfDTOs;
using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Application.DTO.UserDTOs
{
    public class UserGetDTO
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string ImagePath { get; set; }

        public ICollection<ShelfPutDTO> Shelves { get; set; }

        public ICollection<AuthorGetFromUserDTO> Authors { get; set; }

        public ICollection<Review> Reviews { get; set; }
    }
}
