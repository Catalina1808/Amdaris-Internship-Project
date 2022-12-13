using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Application.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string ImagePath { get; set; }

        public ICollection<Shelf> BookShelves { get; }

        public ICollection<User> Friends { get; set; }

        public ICollection<UserAuthor> Authors { get; set; }

        public ICollection<Review> Reviews { get; set; }
    }
}
