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

        public async Task<ShelfBook> AddBookToShelfAsync(ShelfBook book, int shelfId)
        {
            var shelf = await _context.Shelves.SingleOrDefaultAsync(s => s.Id == shelfId);
            if (shelf != null && book != null)
            {
                shelf.Books.Add(book);
                return book;
            } 
            throw new ArgumentNullException();
        }

        public async Task<Shelf> AddShelfAsync(Shelf shelf)
        {
            await _context.Shelves.AddAsync(shelf);
            return shelf;
        }

        public async Task DeleteBookFromShelfAsync(ShelfBook book, int shelfId)
        {
            var shelf = await _context.Shelves.SingleOrDefaultAsync(s => s.Id == shelfId);

            if (shelf == null || !shelf.Books.Remove(book))
            {
                throw new ArgumentNullException();
            }
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
            var shelf = await _context.Shelves.SingleOrDefaultAsync(s => s.Id == id);
            if (shelf == null)
            {
                throw new Application.Exceptions.ShelfNotFoundException("Exception occured, shelf not found!");
            }
            return shelf;
        }
    }
}
