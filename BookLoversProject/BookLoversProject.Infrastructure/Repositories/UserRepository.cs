using BookLoversProject.Application.Exceptions;
using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private List<User> users;

        public UserRepository(List<User> users)
        {
            this.users = users;
        }

        public User AddReader(User user)
        {
            users.Add(user);
            user.Id = users.Count;
            return user;
        }

        public void AddShelfToUser(Shelf shelf, User user)
        {
            user.BookShelves.Add(shelf);
        }

        public void DeleteUser(User user)
        {
            if (!users.Remove(user))
            {
                throw new Exception("Exception occured, user not found!");
            }
        }

        public void DeleteShelfFromUser(Shelf shelf, User user)
        {
            if (!user.BookShelves.Remove(shelf))
            {
                throw new ShelfNotFoundException("Exception occured, shelf not found!");
            }
        }

        public List<User> GetAllUsers()
        {
            return users;
        }

        public User GetUserById(int id)
        {
            var user = users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                throw new Exception("Exception occured, user not found!");
            }
            return user;
        }
    }
}
