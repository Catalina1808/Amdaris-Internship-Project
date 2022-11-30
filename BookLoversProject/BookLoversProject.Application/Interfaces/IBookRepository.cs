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

        void AddAuthorToBook(Book book, Author author);

        void DeleteAuthorFromBook(Book book, Author author);

        void AddReviewToBook(Review review, Book book);

        void DeleteReviewFromBook(Review review, Book book);

        void AddGenreToBook(Genre genre, Book book);

        void DeleteGenreFromBook(Genre genre, Book book);
    }
}
