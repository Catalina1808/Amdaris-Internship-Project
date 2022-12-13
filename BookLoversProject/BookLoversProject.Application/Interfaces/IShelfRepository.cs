using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Application.Interfaces
{
    public interface IShelfRepository
    {
        Task<Shelf> AddShelfAsync(Shelf shelf);

        Task<Shelf> GetShelfByIdAsync(int id);

        Task DeleteShelfAsync(int id);
    }
}
