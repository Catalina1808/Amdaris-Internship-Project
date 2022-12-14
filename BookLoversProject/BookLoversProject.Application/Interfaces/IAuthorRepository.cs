using BookLoversProject.Domain.Domain;
using System.Threading.Tasks;

namespace BookLoversProject.Application.Interfaces
{
    public interface IAuthorRepository
    {
        Task<Author> AddAuthorAsync(Author author);

        Task<Author> GetAuthorByIdAsync(int id);

        Task<ICollection<Author>> GetAllAuthorsAsync();

        void DeleteAuthor(Author author);

        void UpdateAuthor(Author author);
    }
}
