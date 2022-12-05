using BookLoversProject.Application.Exceptions;
using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Infrastructure.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ApplicationContext _context;

        public AuthorRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Author AddAuthor(Author author)
        {
            _context.Authors.Add(author);
            author.Id = _context.Authors.Count();
            return author;
        }

        public void AddBookToAuthor(int authorId, BookAuthor book)
        {
            var author = _context.Authors.FirstOrDefault(x => x.Id == authorId);
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
            var author = _context.Authors.FirstOrDefault(x => x.Id == authorId);
            if (author == null || !author.Books.Remove(book))
            {
                throw new Exception("Book could not be deleted!");
            }
        }

        public void AddFollowerToAuthor(UserAuthor follower, int authorId)
        {
            var author = _context.Authors.FirstOrDefault(x => x.Id == authorId);
            if (author != null)
            {
                author.Followers.Add(follower);
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public void DeleteAuthor(int id)
        {
            var author = _context.Authors.FirstOrDefault(x => x.Id == id);
            if(author == null)
            {
                throw new ArgumentNullException("There is no author with the given ID.");
            }
            _context.Authors.Remove(author);
        }

        public void DeleteFollowerFromAuthor(UserAuthor follower, int authorId)
        {
            var author = _context.Authors.FirstOrDefault(x => x.Id == authorId);
            if (author == null || !author.Followers.Remove(follower))
            {
                throw new Exception("Follower could not be deleted!");
            }
        }

        public Author GetAuthorById(int id)
        {
            var author = _context.Authors.FirstOrDefault(x => x.Id == id);
            if (author == null)
            {
                throw new Exception("Exception occured, author not found!");
            }
            return author;
        }

        public List<Author> GetAllAuthors()
        {
            return _context.Authors.ToList();
        }
    }
}
