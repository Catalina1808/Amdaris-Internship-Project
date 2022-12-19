using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Application.Interfaces
{
    public interface IGenreRepository
    {
        Task<Genre> AddGenreAsync(Genre genre);

        Task<Genre> GetGenreByIdAsync(int id);

        Task<ICollection<Genre>> GetAllGenresAsync();

        void DeleteGenre(Genre genre);

        Task UpdateGenreAsync(Genre genre);
    }
}
