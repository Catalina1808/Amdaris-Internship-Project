using BookLoversProject.Application.Exceptions;
using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Infrastructure.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly ApplicationContext _context;

        public GenreRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Genre AddGenre(Genre genre)
        {
            _context.Genres.Add(genre);
            return genre;
        }

        public void DeleteGenre(int id)
        {
            var genre = _context.Genres.FirstOrDefault(x => x.Id == id);
            if(genre == null)
            {
                throw new ArgumentNullException("There is no genre with the given ID.");
            }
            _context.Genres.Remove(genre);
        }

        public List<Genre> GetAllGenres()
        {
            return _context.Genres.ToList();
        }

        public Genre GetGenreById(int id)
        {
            var genre = _context.Genres.FirstOrDefault(x => x.Id == id);
            if (genre == null)
            {
                throw new Exception("Exception occured, genre not found!");
            }
            return genre;
        }

        public void AddBookToGenre(GenreBook genreBook, int genreId)
        {
            var genre = _context.Genres.FirstOrDefault(x => x.Id == genreId);
            if (genre != null && genreBook != null)
            {
                genre.Books.Add(genreBook);
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public void DeleteBookFromGenre(GenreBook genreBook, int genreId)
        {
            var genre = _context.Genres.FirstOrDefault(x => x.Id == genreId);
            if(genre == null || !genre.Books.Remove(genreBook))
            {
                throw new ArgumentNullException();
            }
        }
    }
}
