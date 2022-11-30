using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Infrastructure.Repositories
{
    public class ShelfRepository : IShelfRepository
    {
        private List<Shelf> shelves;

        public ShelfRepository(List<Shelf> shelfs)
        {
            this.shelves = shelfs;
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
            shelves.Add(shelf);
            shelf.Id = shelves.Count;
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
            if (!shelves.Remove(shelf))
            {
                throw new Application.Exceptions.ShelfNotFoundException("Exception occured, shelf not found!");
            }
        }

        public Shelf GetShelfById(int id)
        {
            var shelf = shelves.FirstOrDefault(x => x.Id == id);
            if (shelf == null)
            {
                throw new Application.Exceptions.ShelfNotFoundException("Exception occured, shelf not found!");
            }
            return shelf;
        }
    }
}
