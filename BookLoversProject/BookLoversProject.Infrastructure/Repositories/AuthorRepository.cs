using BookLoversProject.Application.Exceptions;
using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;
using Microsoft.EntityFrameworkCore;

namespace BookLoversProject.Infrastructure.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ApplicationContext _context;

        public AuthorRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Author> AddAuthorAsync(Author author)
        {
            await _context.Authors.AddAsync(author);
            return author;
        }

        public async Task AddBookToAuthorAsync(int authorId, BookAuthor book)
        {
            var author = await _context.Authors.SingleOrDefaultAsync(x => x.Id == authorId);
            if (author != null)
            {
                author.Books.Add(book);
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public async Task DeleteBookFromAuthorAsync(int authorId, BookAuthor book)
        {
            var author = await _context.Authors.SingleOrDefaultAsync(x => x.Id == authorId);
            if (author == null || !author.Books.Remove(book))
            {
                throw new Exception("Book could not be deleted!");
            }
        }

        public async Task AddFollowerToAuthorAsync(UserAuthor follower, int authorId)
        {
            var author = await _context.Authors.SingleOrDefaultAsync(x => x.Id == authorId);
            if (author != null)
            {
                author.Followers.Add(follower);
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public async Task DeleteAuthorAsync(int id)
        {
            var author = await _context.Authors.SingleOrDefaultAsync(x => x.Id == id);
            if(author == null)
            {
                throw new ArgumentNullException("There is no author with the given ID.");
            }
            _context.Authors.Remove(author);
        }

        public async Task DeleteFollowerFromAuthorAsync(UserAuthor follower, int authorId)
        {
            var author = await _context.Authors.SingleOrDefaultAsync(x => x.Id == authorId);
            if (author == null || !author.Followers.Remove(follower))
            {
                throw new Exception("Follower could not be deleted!");
            }
        }

        public async Task<Author> GetAuthorByIdAsync(int id)
        {
            var author = await _context.Authors.SingleOrDefaultAsync(x => x.Id == id);
            if (author == null)
            {
                throw new Exception("Exception occured, author not found!");
            }
            return author;
        }

        public async Task<ICollection<Author>> GetAllAuthorsAsync()
        {
            return await _context.Authors.ToListAsync();
        }
    }
}
