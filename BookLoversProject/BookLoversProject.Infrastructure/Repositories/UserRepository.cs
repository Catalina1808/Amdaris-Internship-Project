using BookLoversProject.Application.Exceptions;
using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;
using Microsoft.EntityFrameworkCore;

namespace BookLoversProject.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _context;

        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<User> AddReaderAsync(User user)
        {
            await _context.Users.AddAsync(user);  
            return user;
        }

        public async Task AddShelfToUserAsync(Shelf shelf, int userId)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Id == userId);
            if (user != null)
            {
                user.BookShelves.Add(shelf);
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Id == id);
            if (user == null)
            {
                throw new Exception("Exception occured, user not found!");
            }
            _context.Users.Remove(user);
        }

        public async Task DeleteShelfFromUserAsync(Shelf shelf, int userId)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Id == userId);
            if (user == null || !user.BookShelves.Remove(shelf))
            {
                throw new ShelfNotFoundException("Exception occured, shelf not found!");
            }
        }

        public async Task<ICollection<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Id == id);
            if (user == null)
            {
                throw new Exception("Exception occured, user not found!");
            }
            return user;
        }
    }
}
