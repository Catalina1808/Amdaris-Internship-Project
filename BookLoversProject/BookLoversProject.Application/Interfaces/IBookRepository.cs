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
    }
}
