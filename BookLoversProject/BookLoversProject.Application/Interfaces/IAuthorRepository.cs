using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Application.Interfaces
{
    public interface IAuthorRepository
    {
        Author AddAuthor(Author author);

        Author GetAuthorById(int id);

        List<Author> GetAllAuthors();

        void DeleteAuthor(Author author);

        public void AddFollowerToAuthor(AbstractUser follower, Author author);

        public void DeleteFollowerFromAuthor(AbstractUser follower, Author author);
    }
}
