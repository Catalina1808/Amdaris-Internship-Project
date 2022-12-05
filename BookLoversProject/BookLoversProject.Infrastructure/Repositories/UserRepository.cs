using BookLoversProject.Application.Exceptions;
using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _context;

        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }

        public User AddReader(User user)
        {
            _context.Add(user);
            user.Id = _context.Users.Count();
            return user;
        }

        public void AddShelfToUser(Shelf shelf, int userId)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == userId);
            if (user != null)
            {
                user.BookShelves.Add(shelf);
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public void DeleteUser(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                throw new Exception("Exception occured, user not found!");
            }
            _context.Users.Remove(user);
        }

        public void DeleteShelfFromUser(Shelf shelf, int userId)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == userId);
            if (user == null || !user.BookShelves.Remove(shelf))
            {
                throw new ShelfNotFoundException("Exception occured, shelf not found!");
            }
        }

        public ICollection<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public User GetUserById(int id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                throw new Exception("Exception occured, user not found!");
            }
            return user;
        }
    }
}
