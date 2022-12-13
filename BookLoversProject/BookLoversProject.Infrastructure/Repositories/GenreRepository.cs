using BookLoversProject.Application.Exceptions;
using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;
using Microsoft.EntityFrameworkCore;

namespace BookLoversProject.Infrastructure.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly ApplicationContext _context;

        public GenreRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Genre> AddGenreAsync(Genre genre)
        {
            await _context.Genres.AddAsync(genre);
            return genre;
        }

        public async Task DeleteGenreAsync(int id)
        {
            var genre = await _context.Genres.SingleOrDefaultAsync(x => x.Id == id);
            if(genre == null)
            {
                throw new ArgumentNullException("There is no genre with the given ID.");
            }
            _context.Genres.Remove(genre);
        }

        public async Task<ICollection<Genre>> GetAllGenresAsync()
        {
            return await _context.Genres
                .Include(g => g.Books)
                .ToListAsync();
        }

        public async Task<Genre> GetGenreByIdAsync(int id)
        {
            var genre = await _context.Genres
                .Include(g => g.Books)
                .SingleOrDefaultAsync(x => x.Id == id);

            if (genre == null)
            {
                throw new Exception("Exception occured, genre not found!");
            }

            return genre;
        }
    }
}
