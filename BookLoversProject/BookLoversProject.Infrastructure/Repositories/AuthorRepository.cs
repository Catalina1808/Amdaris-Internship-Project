using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Infrastructure.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private List<Author> authors;

        public AuthorRepository(List<Author> authors)
        {
            this.authors = authors;
        }

        public Author AddAuthor(Author author)
        {
            authors.Add(author);
            return author;
        }

        public void AddFollowerToAuthor(IUser follower, Author author)
        {
            author.Followers.Add(follower);
        }

        public void DeleteAuthor(Author author)
        {
            authors.Remove(author);
        }

        public void DeleteFollowerFromAuthor(IUser follower, Author author)
        {
            if (!author.Followers.Remove(follower))
            {
                throw new Exception("Follower not found!");
            }
        }

        public Author GetAuthorById(int id)
        {
            var author = authors.FirstOrDefault(x => x.Id == id);
            if (author == null)
            {
                throw new Exception("Exception occured, author not found!");
            }
            return author;
        }

        public List<Author> GetAllAuthors()
        {
            return authors;
        }
    }
}
