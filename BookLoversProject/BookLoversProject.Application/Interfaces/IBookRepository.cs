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

        Task DeleteReviewFromBookAsync(Review review, int bookId);

        Task AddGenreToBookAsync(GenreBook genre, int bookId);

        Task DeleteGenreFromBookAsync(GenreBook genre, int bookId);

        Task AddShelfToBookAsync(ShelfBook shelf, int bookId);

        Task DeleteShelfFromBookAsync(ShelfBook shelf, int bookId);
    }
}
