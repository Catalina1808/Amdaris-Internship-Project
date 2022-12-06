using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Infrastructure.Repositories
{
    public class ShelfRepository : IShelfRepository
    {
        private readonly ApplicationContext _context;

        public ShelfRepository(ApplicationContext context)
        {
            _context = context;
        }

        public ShelfBook AddBookToShelf(ShelfBook book, int shelfId)
        {
            var shelf = _context.Shelves.FirstOrDefault(s => s.Id == shelfId);
            if (shelf != null && book != null)
            {
                shelf.Books.Add(book);
                return book;
            } 
            throw new ArgumentNullException();
        }

        public Shelf AddShelf(Shelf shelf)
        {
            _context.Shelves.Add(shelf);
            return shelf;
        }

        public void DeleteBookFromShelf(ShelfBook book, int shelfId)
        {
            var shelf = _context.Shelves.FirstOrDefault(s => s.Id == shelfId);

            if (shelf == null || !shelf.Books.Remove(book))
            {
                throw new ArgumentNullException();
            }
        }

        public void DeleteShelf(int id)
        {
            var shelf = _context.Shelves.FirstOrDefault(s => s.Id == id);
            if (shelf == null)
            {
                throw new Application.Exceptions.ShelfNotFoundException("Exception occured, shelf not found!");
            }
            _context.Shelves.Remove(shelf);
        }

        public Shelf GetShelfById(int id)
        {
            var shelf = _context.Shelves.FirstOrDefault(s => s.Id == id);
            if (shelf == null)
            {
                throw new Application.Exceptions.ShelfNotFoundException("Exception occured, shelf not found!");
            }
            return shelf;
        }
    }
}
