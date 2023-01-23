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

        public int GetBooksCount()
        {
            return _context.Books.Count();
        }

        public async Task<ICollection<Book>> GetPagedBooksAsync(int pageNumber, int pageSize)
        {
            return await _context.Books
                .Include(b => b.Genres)
                .ThenInclude(gb => gb.Genre)
                .Include(b => b.Authors)
                .ThenInclude(ba => ba.Author)
                .Include(s => s.Shelves)
                .ThenInclude(sb => sb.Shelf)
                .Include(b => b.Reviews)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
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

        public async Task UpdateBookAsync(Book book)
        {
            var oldBook = await GetBookByIdAsync(book.Id);

            book.Reviews = oldBook.Reviews;
            book.Authors = oldBook.Authors;
            book.Shelves = oldBook.Shelves;
            book.Genres = oldBook.Genres;

            _context.Entry(oldBook).CurrentValues.SetValues(book);
        }
    }
}
