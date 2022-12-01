using BookLoversProject.Application.Exceptions;
using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Infrastructure.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private List<Author> _authors;

        public AuthorRepository(List<Author> authors)
        {
            _authors = authors;
        }

        public AuthorRepository()
        {
            _authors= new List<Author>();
        }

        public Author AddAuthor(Author author)
        {
            _authors.Add(author);
            author.Id = _authors.Count;
            return author;
        }

        public void AddBookToAuthor(int authorId, BookAuthor book)
        {
            var author = _authors.FirstOrDefault(x => x.Id == authorId);
            if (author != null)
            {
                author.Books.Add(book);
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public void DeleteBookFromAuthor(int authorId, BookAuthor book)
        {
            var author = _authors.FirstOrDefault(x => x.Id == authorId);
            if (author == null || !author.Books.Remove(book))
            {
                throw new Exception("Book could not be deleted!");
            }
        }

        public void AddFollowerToAuthor(UserAuthor follower, int authorId)
        {
            var author = _authors.FirstOrDefault(x => x.Id == authorId);
            if (author != null)
            {
                author.Followers.Add(follower);
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public void DeleteAuthor(Author author)
        {
            _authors.Remove(author);
        }

        public void DeleteFollowerFromAuthor(UserAuthor follower, int authorId)
        {
            var author = _authors.FirstOrDefault(x => x.Id == authorId);
            if (author == null || !author.Followers.Remove(follower))
            {
                throw new Exception("Follower could not be deleted!");
            }
        }

        public Author GetAuthorById(int id)
        {
            var author = _authors.FirstOrDefault(x => x.Id == id);
            if (author == null)
            {
                throw new Exception("Exception occured, author not found!");
            }
            return author;
        }

        public List<Author> GetAllAuthors()
        {
            return _authors;
        }
    }
}
