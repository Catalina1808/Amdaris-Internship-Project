using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Application.Interfaces
{
    public interface IShelfBookRepository
    {
        ShelfBook AddShelfBook(ShelfBook shelfBook);

        ICollection<ShelfBook> GetAllShelfBooks();

        ICollection<ShelfBook> GetShelfBooksByShelfId(int shelfId);

        ICollection<ShelfBook> GetShelfBooksByBookId(int bookId);

        void DeleteShelfBook(ShelfBook shelfBook);
    }
}
