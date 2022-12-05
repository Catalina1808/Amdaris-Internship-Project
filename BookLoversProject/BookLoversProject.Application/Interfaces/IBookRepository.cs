using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Application.Interfaces
{
    public interface IBookRepository
    {
        Book AddBook(Book book);

        Book GetBookById(int id);

        ICollection<Book> GetAllBooks();

        void DeleteBook(int id);

        ICollection<Review> GetReviewsByBookId(int bookId);

        void AddAuthorToBook(int bookId, BookAuthor author);

        void DeleteAuthorFromBook(int bookId, BookAuthor author);

        void AddReviewToBook(Review review, int bookId);

        void DeleteReviewFromBook(Review review, int bookId);

        void AddGenreToBook(GenreBook genre, int bookId);

        void DeleteGenreFromBook(GenreBook genre, int bookId);

        void AddShelfToBook(ShelfBook shelf, int bookId);

        void DeleteShelfFromBook(ShelfBook shelf, int bookId);
    }
}
