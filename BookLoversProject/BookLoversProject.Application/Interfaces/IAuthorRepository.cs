using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Application.Interfaces
{
    public interface IAuthorRepository
    {
        Author AddAuthor(Author author);

        Author GetAuthorById(int id);

        List<Author> GetAllAuthors();

        void DeleteAuthor(Author author);

        void AddFollowerToAuthor(User follower, Author author);

        void DeleteFollowerFromAuthor(User follower, Author author);
    }
}
