using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Application.Interfaces
{
    public interface IShelfRepository
    {
        Task<Shelf> AddShelf(Shelf shelf);

        Task<Shelf> GetShelfById(int id);

        Task DeleteShelf(int id);

        Task<ShelfBook> AddBookToShelf(ShelfBook book, int shelfId);

        Task DeleteBookFromShelf(ShelfBook book, int shelfId);
    }
}
