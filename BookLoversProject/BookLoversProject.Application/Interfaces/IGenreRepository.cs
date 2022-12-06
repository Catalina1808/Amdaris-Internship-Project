using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Application.Interfaces
{
    public interface IGenreRepository
    {
        Task<Genre> AddGenre(Genre genre);

        Task<Genre> GetGenreById(int id);

        Task<ICollection<Genre>> GetAllGenres();

        Task DeleteGenre(int id);

        Task AddBookToGenre(GenreBook genreBook, int genreId);

        Task DeleteBookFromGenre(GenreBook genreBook, int genreId);
    }
}
