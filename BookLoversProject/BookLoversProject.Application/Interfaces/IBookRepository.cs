using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Application.Interfaces
{
    public interface IBookRepository
    {
        Book AddBook(Book book);

        Book GetBookById(int id);

        List<Book> GetAllBooks();

        void DeleteBook(Book book);

        User GetReviewFromBook(int reviewId, int bookId);

        void AddReviewToBook(User review, Book book);

        void DeleteReviewFromBook(User review, Book book);
    }
}
