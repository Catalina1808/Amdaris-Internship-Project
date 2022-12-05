using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Application.Interfaces
{
    public interface IAuthorRepository
    {
        Author AddAuthor(Author author);

        Author GetAuthorById(int id);

        List<Author> GetAllAuthors();

        void DeleteAuthor(int id);

        void AddFollowerToAuthor(UserAuthor follower, int authorId);

        void DeleteFollowerFromAuthor(UserAuthor follower, int authorId);

        void AddBookToAuthor(int authorId, BookAuthor book);

        void DeleteBookFromAuthor(int authorId, BookAuthor book);
    }
}
