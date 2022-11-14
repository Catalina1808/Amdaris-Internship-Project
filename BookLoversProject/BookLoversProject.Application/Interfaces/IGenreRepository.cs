using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Application.Interfaces
{
    public interface IGenreRepository
    {
        Genre AddGenre(Genre genre);

        Genre GetGenreById(int id);

        List<Genre> GetAllGenres();

        void DeleteGenre(Genre genre);
    }
}
