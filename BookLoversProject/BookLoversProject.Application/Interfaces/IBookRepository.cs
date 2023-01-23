using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Application.Interfaces
{
    public interface IBookRepository
    {
        Task<Book> AddBookAsync(Book book);

        Task<Book> GetBookByIdAsync(int id);

        Task<ICollection<Book>> GetAllBooksAsync();

        int GetBooksCount();

        int GetBooksCountByGenre(int genreId);

        Task<ICollection<Book>> GetPagedBooksAsync(int pageNumber, int pageSize);

        Task<ICollection<Book>> GetPagedBooksByGenreAsync(int pageNumber, int pageSize, int genreId);

        void DeleteBook(Book book);

        Task UpdateBookAsync(Book book);
    }
}
