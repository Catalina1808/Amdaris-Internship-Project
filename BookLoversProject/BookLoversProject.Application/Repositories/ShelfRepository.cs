using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Application.Repositories
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
            shelf.Books.Add(book);
            return book;
        }

        public Shelf AddShelf(Shelf shelf)
        {
            shelfs.Add(shelf);
            return shelf;
        }

        public void DeleteBookFromShelf(Book book, Shelf shelf)
        {
            if(!shelf.Books.Remove(book))
            {
                throw new Exceptions.BookNotFoundException("Exception occured, book not found!");
            }
        }

        public void DeleteShelf(Shelf shelf)
        {
            if (!shelfs.Remove(shelf))
            {
                throw new Exceptions.ShelfNotFoundException("Exception occured, shelf not found!");
            }
        }

        public Shelf GetShelfById(int id)
        {
            var shelf = shelfs.FirstOrDefault(x => x.Id == id);
            if (shelf == null)
            {
                throw new Exceptions.ShelfNotFoundException("Exception occured, shelf not found!");
            }
            return shelf;
        }
    }
}
