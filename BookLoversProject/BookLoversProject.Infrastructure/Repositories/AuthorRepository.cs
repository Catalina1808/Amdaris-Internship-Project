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
            author.Id = authors.Count;
            return author;
        }

        public void AddFollowerToAuthor(User follower, Author author)
        {
            var userAutor = new UserAuthor();
            userAutor.Author = author;
            userAutor.User = follower;
            userAutor.AuthorId = author.Id;
            userAutor.UserId = follower.Id;

            author.Followers.Add(userAutor);
            follower.Authors.Add(userAutor);
        }

        public void DeleteAuthor(Author author)
        {
            authors.Remove(author);
        }

        public void DeleteFollowerFromAuthor(User follower, Author author)
        {
            var userAuthor = author.Followers.FirstOrDefault(item => item.User == follower);

            if (!author.Followers.Remove(userAuthor))
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
