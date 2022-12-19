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

        public void DeleteGenre(Genre genre)
        {
            _context.Genres.Remove(genre);
        }

        public async Task<ICollection<Genre>> GetAllGenresAsync()
        {
            return await _context.Genres
                .Include(g => g.Books)
                .ThenInclude(gb => gb.Book)
                .ToListAsync();
        }

        public async Task<Genre> GetGenreByIdAsync(int id)
        {
            var genre = await _context.Genres
                .Include(g => g.Books)
                .ThenInclude(gb => gb.Book)
                .SingleOrDefaultAsync(x => x.Id == id);

            if (genre == null)
            {
                throw new ObjectNotFoundException("Exception occured, genre not found!");
            }

            return genre;
        }

        public async Task UpdateGenreAsync(Genre genre)
        {
            var oldGenre = await GetGenreByIdAsync(genre.Id);

            genre.Books = oldGenre.Books;

            _context.Entry(oldGenre).CurrentValues.SetValues(genre);
        }
    }
}
