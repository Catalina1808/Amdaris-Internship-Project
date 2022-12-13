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

        public async Task DeleteAuthorAsync(int id)
        {
            var author = await _context.Authors.SingleOrDefaultAsync(x => x.Id == id);
            if(author == null)
            {
                throw new ArgumentNullException("There is no author with the given ID.");
            }
            _context.Authors.Remove(author);
        }

        public async Task<Author> GetAuthorByIdAsync(int id)
        {
            var author = await _context.Authors
                .Include(a => a.Books)
                .Include(a => a.Followers)
                .SingleOrDefaultAsync(x => x.Id == id);

            if (author == null)
            {
                throw new ArgumentNullException("Exception occured, author not found!");
            }

            return author;
        }

        public async Task<ICollection<Author>> GetAllAuthorsAsync()
        {
            return await _context.Authors
                .Include(a => a.Books)
                .Include(a => a.Followers)
                .ToListAsync();
        }

        public void UpdateAuthor(Author author)
        {
            _context.Update(author);
        }
    }
}