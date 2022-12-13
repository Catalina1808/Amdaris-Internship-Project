using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Application.Interfaces
{
    public interface IGenreRepository
    {
        Task<Genre> AddGenreAsync(Genre genre);

        Task<Genre> GetGenreByIdAsync(int id);

        Task<ICollection<Genre>> GetAllGenresAsync();

        Task DeleteGenreAsync(int id);
    }
}
