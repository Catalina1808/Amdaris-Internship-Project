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

        public void DeleteAuthor(Author author)
        {
            _context.Authors.Remove(author);
        }

        public async Task<Author> GetAuthorByIdAsync(int id)
        {
            var author = await _context.Authors
                .Include(a => a.Books)
                .ThenInclude(ba => ba.Book)
                .ThenInclude(gb => gb.Genres)
                .ThenInclude(g => g.Genre)
                .Include(a => a.Followers)
                .ThenInclude(ua => ua.User)
                .SingleOrDefaultAsync(x => x.Id == id);

            if (author == null)
            {
                throw new ObjectNotFoundException("Exception occured, author not found!");
            }

            return author;
        }

        public async Task<ICollection<Author>> GetAllAuthorsAsync()
        {
            return await _context.Authors
                .Include(a => a.Books)
                .ThenInclude(ba => ba.Book)
                .Include(a => a.Followers)
                .ThenInclude(ua => ua.User)
                .ToListAsync();
        }

        public async Task UpdateAuthorAsync(Author author)
        {
            var oldAuthor = await GetAuthorByIdAsync(author.Id);

            author.Books = oldAuthor.Books;
            author.Followers = oldAuthor.Followers;

            _context.Entry(oldAuthor).CurrentValues.SetValues(author);
        }
    }
}