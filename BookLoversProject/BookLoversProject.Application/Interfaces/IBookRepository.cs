using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Application.Interfaces
{
    public interface IBookRepository
    {
        Book AddBook(Book book);

        Book GetBookById(int id);

        List<Book> GetAllBooks();

        void DeleteBook(Book book);

        Review GetReviewFromBook(int reviewId, int bookId);

        void AddReviewToBook(Review review, Book book);

        void DeleteReviewFromBook(Review review, Book book);
    }
}
