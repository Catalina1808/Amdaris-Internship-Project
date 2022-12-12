using BookLoversProject.Domain.Domain;
using System.Threading.Tasks;

namespace BookLoversProject.Application.Interfaces
{
    public interface IAuthorRepository
    {
        Task<Author> AddAuthorAsync(Author author);

        Task<Author> GetAuthorByIdAsync(int id);

        Task<ICollection<Author>> GetAllAuthorsAsync();

        Task DeleteAuthorAsync(int id);

        Task AddFollowerToAuthorAsync(UserAuthor follower, int authorId);

        Task DeleteFollowerFromAuthorAsync(UserAuthor follower, int authorId);

        Task AddBookToAuthorAsync(int authorId, BookAuthor book);

        Task DeleteBookFromAuthorAsync(int authorId, BookAuthor book);
    }
}
