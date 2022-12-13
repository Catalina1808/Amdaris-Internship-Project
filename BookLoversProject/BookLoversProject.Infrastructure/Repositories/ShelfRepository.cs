using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;
using Microsoft.EntityFrameworkCore;

namespace BookLoversProject.Infrastructure.Repositories
{
    public class ShelfRepository : IShelfRepository
    {
        private readonly ApplicationContext _context;

        public ShelfRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Shelf> AddShelfAsync(Shelf shelf)
        {
            await _context.Shelves.AddAsync(shelf);
            return shelf;
        }

        public async Task DeleteShelfAsync(int id)
        {
            var shelf = await _context.Shelves.SingleOrDefaultAsync(s => s.Id == id);
            if (shelf == null)
            {
                throw new Application.Exceptions.ShelfNotFoundException("Exception occured, shelf not found!");
            }
            _context.Shelves.Remove(shelf);
        }

        public async Task<Shelf> GetShelfByIdAsync(int id)
        {
            var shelf = await _context.Shelves
                .Include(s => s.Books)
                .SingleOrDefaultAsync(s => s.Id == id);
            if (shelf == null)
            {
                throw new Application.Exceptions.ShelfNotFoundException("Exception occured, shelf not found!");
            }
            return shelf;
        }

        public async Task<ICollection<Shelf>> GetAllShelvesAsync()
        {
            return await _context.Shelves
                .Include(s => s.Books)
                .ToListAsync();
        }
    }
}
