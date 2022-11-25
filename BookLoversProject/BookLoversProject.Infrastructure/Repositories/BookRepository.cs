using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly List<Book> books;

        public BookRepository()
        {
            books = new List<Book>
            {
                new Book()
                {
                    Id= 1,
                    Title = "title1",
                    Description= "description1"
                }
            };
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
                throw new Application.Exceptions.BookNotFoundException("Exception occured, book not found!");
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
                throw new Application.Exceptions.BookNotFoundException("Exception occured, book not found!");
            }
            return book;
        }

        public Review GetReviewFromBook(int reviewId, int bookId)
        {
            var book = GetBookById(bookId);
            var review = book.ReviewList.FirstOrDefault(x => x.Id == reviewId);
            if (review == null)
            {
                throw new Application.Exceptions.ReviewNotFoundException("Exception occured, review not found!");
            }
            return review;
        }

        public void AddReviewToBook(Review review, Book book)
        {
            if (review == null)
            {
                throw new ArgumentNullException("Exception occured, review not defined!");
            }
            book.ReviewList.Add(review);
        }

        public void DeleteReviewFromBook(Review review, Book book)
        {
            if (!book.ReviewList.Remove(review))
            {
                throw new Application.Exceptions.ReviewNotFoundException("Exception occured, review not found!");
            }
        }
    }
}
