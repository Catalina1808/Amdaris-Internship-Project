using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Application.Interfaces
{
    public interface IShelfRepository
    {
        Task<Shelf> AddShelfAsync(Shelf shelf);

        Task<Shelf> GetShelfByIdAsync(int id);

        Task<ICollection<Shelf>> GetAllShelvesAsync();

        void DeleteShelf(Shelf shelf);

        void UpdateShelf(Shelf shelf);
    }
}
