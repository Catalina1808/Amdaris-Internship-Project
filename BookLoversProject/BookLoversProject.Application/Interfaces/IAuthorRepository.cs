using BookLoversProject.Domain.Domain;
using System.Threading.Tasks;

namespace BookLoversProject.Application.Interfaces
{
    public interface IAuthorRepository
    {
        Task<Author> AddAuthorAsync(Author author);

        Task<Author> GetAuthorByIdAsync(int id);

        Task<ICollection<Author>> GetAllAuthors();

        Task DeleteAuthor(int id);

        Task AddFollowerToAuthor(UserAuthor follower, int authorId);

        Task DeleteFollowerFromAuthor(UserAuthor follower, int authorId);

        Task AddBookToAuthorAsync(int authorId, BookAuthor book);

        Task DeleteBookFromAuthor(int authorId, BookAuthor book);
    }
}
