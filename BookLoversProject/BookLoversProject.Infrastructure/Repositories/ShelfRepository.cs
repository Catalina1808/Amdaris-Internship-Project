using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Infrastructure.Repositories
{
    public class ShelfRepository : IShelfRepository
    {
        private List<Shelf> shelfs;

        public ShelfRepository(List<Shelf> shelfs)
        {
            this.shelfs = shelfs;
        }

        public Book AddBookToShelf(Book book, Shelf shelf)
        {
            //shelf.Books.Add(book);
            var shelfBook = new ShelfBook();
            shelfBook.Shelf = shelf;
            shelfBook.Book = book;
            shelfBook.BookId = book.Id;
            shelfBook.ShelfId = shelf.Id;

            shelf.Books.Add(shelfBook);
            book.Shelves.Add(shelfBook);

            return book;
        }

        public Shelf AddShelf(Shelf shelf)
        {
            shelfs.Add(shelf);
            return shelf;
        }

        public void DeleteBookFromShelf(Book book, Shelf shelf)
        {
            var shelfBook = shelf.Books.FirstOrDefault(item => item.Book == book);

            if (!shelf.Books.Remove(shelfBook))
            {
                throw new Application.Exceptions.BookNotFoundException("Exception occured, book not found!");
            }
        }

        public void DeleteShelf(Shelf shelf)
        {
            if (!shelfs.Remove(shelf))
            {
                throw new Application.Exceptions.ShelfNotFoundException("Exception occured, shelf not found!");
            }
        }

        public Shelf GetShelfById(int id)
        {
            var shelf = shelfs.FirstOrDefault(x => x.Id == id);
            if (shelf == null)
            {
                throw new Application.Exceptions.ShelfNotFoundException("Exception occured, shelf not found!");
            }
            return shelf;
        }
    }
}
