using BookLoversProject.Application.Exceptions;
using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Infrastructure.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private List<Genre> genres;

        public GenreRepository(List<Genre> genres)
        {
            this.genres = genres;
        }

        public GenreRepository()
        {
           genres = new List<Genre>();
        }

        public Genre AddGenre(Genre genre)
        {
            genres.Add(genre);
            genre.Id = genres.Count;
            return genre;
        }

        public void DeleteGenre(Genre genre)
        {
            if (!genres.Remove(genre))
            {
                throw new Exception("Exception occured, genre not found!");
            }
        }

        public List<Genre> GetAllGenres()
        {
            return genres;
        }

        public Genre GetGenreById(int id)
        {
            var genre = genres.FirstOrDefault(x => x.Id == id);
            if (genre == null)
            {
                throw new Exception("Exception occured, genre not found!");
            }
            return genre;
        }

        public void AddBookToGenre(GenreBook genreBook, int genreId)
        {
            var genre = genres.FirstOrDefault(x => x.Id == genreId);
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
            var genre = genres.FirstOrDefault(x => x.Id == genreId);
            if(genre == null || !genre.Books.Remove(genreBook))
            {
                throw new ArgumentNullException();
            }
        }
    }
}
