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

        public async Task AddGenreToBookAsync(GenreBook genre, int bookId)
        {
            var book = await _context.Books.SingleOrDefaultAsync(x => x.Id == bookId);
            if(book != null)
            {
                book.Genres.Add(genre);
            }
            else
            {
                throw new BookNotFoundException();
            }

        }

        public async Task DeleteGenreFromBook(GenreBook genre, int bookId)
        {
            var book = await _context.Books.SingleOrDefaultAsync(x => x.Id == bookId);
            if (book == null || !book.Genres.Remove(genre))
            {
                throw new Exception("Genre could not be deleted!");
            }
        }

        public async Task AddAuthorToBookAsync(int bookId, BookAuthor author)
        {
            var book = await _context.Books.SingleOrDefaultAsync(x => x.Id == bookId);
            if(book != null )
            {
                book.Authors.Add(author);
            }
            else
            {
                throw new BookNotFoundException();
            }
        }

        public async Task DeleteAuthorFromBook(int bookId, BookAuthor author)
        {
            var book = await _context.Books.SingleOrDefaultAsync(x => x.Id == bookId);
            if (book == null || !book.Authors.Remove(author))
            {
                throw new Exception("Genre could not be deleted!");
            }
        }

        public async Task<Book> AddBook(Book book)
        {
            await _context.Books.AddAsync(book);
            return book;
        }

        public async Task DeleteBook(int id)
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
            return await _context.Books.ToListAsync();
        }

        public async Task<Book> GetBookById(int id)
        {
            var book = await _context.Books.SingleOrDefaultAsync(x => x.Id == id);
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

        public async Task AddReviewToBookAsync(Review review, int bookId)
        {
            var book = await _context.Books.SingleOrDefaultAsync(x => x.Id == bookId);
            if (review == null || book == null)
            {
                throw new ArgumentNullException("Exception occured, review or book not defined!");
            }
            book.Reviews.Add(review);
        }

        public async Task DeleteReviewFromBook(Review review, int bookId)
        {
            var book = await _context.Books.SingleOrDefaultAsync(x => x.Id == bookId);
            if (book == null || !book.Reviews.Remove(review))
            {
                throw new ReviewNotFoundException("Exception occured, review not found!");
            }
        }

        public async Task AddShelfToBook(ShelfBook shelf, int bookId)
        {
            var book = await _context.Books.SingleOrDefaultAsync(x => x.Id == bookId);
            if (book != null)
            {
                book.Shelves.Add(shelf);
            }
            else
            {
                throw new BookNotFoundException();
            }
        }

        public async Task DeleteShelfFromBook(ShelfBook shelf, int bookId)
        {
            var book = await _context.Books.SingleOrDefaultAsync(x => x.Id == bookId);
            if (book == null || !book.Shelves.Remove(shelf))
            {
                throw new Exception("Genre could not be deleted!");
            }
        }
    }
}
