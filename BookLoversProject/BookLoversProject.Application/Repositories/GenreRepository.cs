using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Application.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private List<Genre> genres;
        
        public GenreRepository(List<Genre> genres)
        {
            this.genres = genres;
        }

        public Genre AddGenre(Genre genre)
        {
            genres.Add(genre);
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
    }
}
