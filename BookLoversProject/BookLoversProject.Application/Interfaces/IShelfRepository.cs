using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Application.Interfaces
{
    public interface IShelfRepository
    {
        Shelf AddShelf(Shelf shelf);

        Shelf GetShelfById(int id);

        void DeleteShelf(Shelf shelf);

        Book AddBookToShelf(Book book, Shelf shelf);

        void DeleteBookFromShelf(Book book, Shelf shelf);

    }
}
