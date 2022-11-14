using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Application.Repositories
{
    public class BookRepository : IBookRepository
    {
        private List<Book> books;

        public BookRepository()
        {
            books = new List<Book>();
        }

        public Book AddBook(Book book)
        {
            books.Add(book);
            return book;
        }

        public void DeleteBook(Book book)
        {
            if (!books.Remove(book))
            {
                throw new Exceptions.BookNotFoundException("Exception occured, book not found!");
            }
        }

        public List<Book> GetAllBooks()
        {
            return books;
        }

        public Book GetBookById(int id)
        {
            var book = books.FirstOrDefault(x => x.Id == id);
            if (book == null)
            {
                throw new Exceptions.BookNotFoundException("Exception occured, book not found!");
            }
            return book;
        }

        public User GetReviewFromBook(int reviewId, int bookId)
        {
            var book = GetBookById(bookId);
            var review = book.ReviewList.FirstOrDefault(x => x.Id == reviewId);
            if (review == null)
            {
                throw new Exceptions.ReviewNotFoundException("Exception occured, review not found!");
            }
            return review;
        }

        public void AddReviewToBook(User review, Book book)
        {
            if (review == null)
            {
                throw new ArgumentNullException("Exception occured, review not defined!");
            }
            book.ReviewList.Add(review);
        }

        public void DeleteReviewFromBook(User review, Book book)
        {
            if (!book.ReviewList.Remove(review))
            {
                throw new Exceptions.ReviewNotFoundException("Exception occured, review not found!");
            }
        }
    }
}
