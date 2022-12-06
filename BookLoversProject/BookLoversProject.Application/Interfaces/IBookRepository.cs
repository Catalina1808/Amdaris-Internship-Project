using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Application.Interfaces
{
    public interface IBookRepository
    {
        Task<Book> AddBook(Book book);

        Task<Book> GetBookById(int id);

        Task<ICollection<Book>> GetAllBooksAsync();

        Task DeleteBook(int id);

        Task<ICollection<Review>> GetReviewsByBookIdAsync(int bookId);

        Task AddAuthorToBookAsync(int bookId, BookAuthor author);

        Task DeleteAuthorFromBook(int bookId, BookAuthor author);

        Task AddReviewToBookAsync(Review review, int bookId);

        Task DeleteReviewFromBook(Review review, int bookId);

        Task AddGenreToBookAsync(GenreBook genre, int bookId);

        Task DeleteGenreFromBook(GenreBook genre, int bookId);

        Task AddShelfToBook(ShelfBook shelf, int bookId);

        Task DeleteShelfFromBook(ShelfBook shelf, int bookId);
    }
}
