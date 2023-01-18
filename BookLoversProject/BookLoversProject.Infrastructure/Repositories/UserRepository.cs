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

        public void DeleteUser(User user)
        {
            _context.Users.Remove(user);
        }

        public async Task<ICollection<User>> GetAllUsersAsync()
        {
            return await _context.Users
                .Include(u => u.Authors)
                .ThenInclude(ua => ua.Author)
                .Include(u => u.Reviews)
                .Include(u => u.Shelves)
                .ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(string id)
        {
            var user = await _context.Users
                .Include(u => u.Authors)
                .ThenInclude(ua => ua.Author)
                .Include(u => u.Reviews)
                .Include(u => u.Shelves)
                .SingleOrDefaultAsync(x => x.Id == id);

            if (user == null)
            {
                throw new ObjectNotFoundException("Exception occured, user not found!");
            }

            return user;
        }

        public async Task UpdateUserAsync(User user)
        {
            var oldUser = await GetUserByIdAsync(user.Id);

            user.Reviews = oldUser.Reviews;
            user.Shelves = oldUser.Shelves;
            user.Authors = oldUser.Authors;

            _context.Entry(oldUser).CurrentValues.SetValues(user);
        }
    }
}
