using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Application.Interfaces
{
    public interface IBookRepository
    {
        Task<Book> AddBookAsync(Book book);

        Task<Book> GetBookByIdAsync(int id);

        Task<ICollection<Book>> GetAllBooksAsync();

        Task DeleteBookAsync(int id);

        Task<ICollection<Review>> GetReviewsByBookIdAsync(int bookId);

        Task AddAuthorToBookAsync(int bookId, BookAuthor author);

        Task DeleteAuthorFromBookAsync(int bookId, BookAuthor author);

        Task AddReviewToBookAsync(Review review, int bookId);

        Task DeleteReviewFromBook(Review review, int bookId);

        Task AddGenreToBookAsync(GenreBook genre, int bookId);

        Task DeleteGenreFromBookAsync(GenreBook genre, int bookId);

        Task AddShelfToBook(ShelfBook shelf, int bookId);

        Task DeleteShelfFromBook(ShelfBook shelf, int bookId);
    }
}
