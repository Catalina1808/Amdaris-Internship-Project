using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Application.Interfaces
{
    public interface IShelfRepository
    {
        Shelf AddShelf(Shelf shelf);

        Shelf GetShelfById(int id);

        void DeleteShelf(int id);

        ShelfBook AddBookToShelf(ShelfBook book, int shelfId);

        void DeleteBookFromShelf(ShelfBook book, int shelfId);
    }
}
