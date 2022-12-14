using BookLoversProject.Application.Exceptions;
using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;
using Microsoft.EntityFrameworkCore;

namespace BookLoversProject.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationContext _context;

        public BookRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Book> AddBookAsync(Book book)
        {
            await _context.Books.AddAsync(book);
            return book;
        }

        public void DeleteBook(Book book)
        {
            _context.Books.Remove(book);
        }

        public async Task<ICollection<Book>> GetAllBooksAsync()
        {
            return await _context.Books
                .Include(b => b.Genres)
                .ThenInclude(gb => gb.Genre)
                .Include(b => b.Authors)
                .ThenInclude(ba => ba.Author)
                .Include(s => s.Shelves)
                .ThenInclude(sb => sb.Shelf)
                .Include(b => b.Reviews)
                .ToListAsync();
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            var book = await _context.Books
                .Include(b => b.Genres)
                .ThenInclude(gb => gb.Genre)
                .Include(b => b.Authors)
                .ThenInclude(ba => ba.Author)
                .Include(s => s.Shelves)
                .ThenInclude(sb => sb.Shelf)
                .Include(b => b.Reviews)
                .SingleOrDefaultAsync(x => x.Id == id);

            if (book == null)
            {
                throw new ObjectNotFoundException("Exception occured, book not found!");
            }

            return book;
        }

        public void UpdateBook(Book book)
        {
            _context.Update(book);
        }
    }
}
