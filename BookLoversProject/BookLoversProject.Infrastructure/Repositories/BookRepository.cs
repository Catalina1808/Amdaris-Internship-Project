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

        public async Task DeleteBookAsync(int id)
        {
            var book = await _context.Books.SingleOrDefaultAsync(x => x.Id == id);
            if(book == null)
            {
                throw new BookNotFoundException();
            }
            _context.Books.Remove(book);
        }

        public async Task<ICollection<Book>> GetAllBooksAsync()
        {
            return await _context.Books
                .Include(b => b.Genres)
                .Include(b => b.Authors)
                .Include(b => b.Reviews)
                .ToListAsync();
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            var book = await _context.Books
                .Include(b => b.Genres)
                .Include(b => b.Authors)
                .Include(b => b.Reviews)
                .SingleOrDefaultAsync(x => x.Id == id);

            if (book == null)
            {
                throw new BookNotFoundException("Exception occured, book not found!");
            }

            return book;
        }

        public async Task<ICollection<Review>> GetReviewsByBookIdAsync(int bookId)
        {
            var book = await _context.Books.SingleOrDefaultAsync(x => x.Id == bookId);
            if (book == null || book.Reviews == null)
            {
                throw new ReviewNotFoundException("Exception occured, _genres not found!");
            }

            return book.Reviews;
        }
    }
}
