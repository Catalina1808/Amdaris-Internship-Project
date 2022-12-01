using BookLoversProject.Application.Exceptions;
using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private List<User> _users;

        public UserRepository(List<User> users)
        {
            this._users = users;
        }

        public User AddReader(User user)
        {
            _users.Add(user);
            user.Id = _users.Count;
            return user;
        }

        public void AddShelfToUser(Shelf shelf, int userId)
        {
            var user = _users.FirstOrDefault(x => x.Id == userId);
            if (user != null)
            {
                user.BookShelves.Add(shelf);
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public void DeleteUser(User user)
        {
            if (!_users.Remove(user))
            {
                throw new Exception("Exception occured, user not found!");
            }
        }

        public void DeleteShelfFromUser(Shelf shelf, int userId)
        {
            var user = _users.FirstOrDefault(x => x.Id == userId);
            if (user == null || !user.BookShelves.Remove(shelf))
            {
                throw new ShelfNotFoundException("Exception occured, shelf not found!");
            }
        }

        public List<User> GetAllUsers()
        {
            return _users;
        }

        public User GetUserById(int id)
        {
            var user = _users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                throw new Exception("Exception occured, user not found!");
            }
            return user;
        }
    }
}
