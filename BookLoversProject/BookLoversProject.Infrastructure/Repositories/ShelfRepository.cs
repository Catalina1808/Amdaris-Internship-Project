using BookLoversProject.Application.Exceptions;
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

        public void DeleteShelf(Shelf shelf)
        {
            _context.Shelves.Remove(shelf);
        }

        public async Task<Shelf> GetShelfByIdAsync(int id)
        {
            var shelf = await _context.Shelves
                .Include(s => s.Books)
                .ThenInclude(sb => sb.Book)
                .SingleOrDefaultAsync(s => s.Id == id);
            if (shelf == null)
            {
                throw new ObjectNotFoundException("Exception occured, shelf not found!");
            }
            return shelf;
        }

        public async Task<ICollection<Shelf>> GetAllShelvesAsync()
        {
            return await _context.Shelves
                .Include(s => s.Books)
                .ThenInclude(sb => sb.Book)
                .ToListAsync();
        }

        public async Task UpdateShelfAsync(Shelf shelf)
        {
            var oldShelf = await GetShelfByIdAsync(shelf.Id);

            shelf.UserId = oldShelf.UserId;

            _context.Entry(oldShelf).CurrentValues.SetValues(shelf);
        }
    }
}
