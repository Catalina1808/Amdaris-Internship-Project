using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Infrastructure.Repositories
{
    public class ShelfRepository : IShelfRepository
    {
        private List<Shelf> _shelves;

        public ShelfRepository(List<Shelf> shelfs)
        {
            this._shelves = shelfs;
        }

        public ShelfBook AddBookToShelf(ShelfBook book, int shelfId)
        {
            var shelf = _shelves.FirstOrDefault(x => x.Id == shelfId);
            if (shelf != null && book != null)
            {
                shelf.Books.Add(book);
                return book;
            } 
            throw new ArgumentNullException();
        }

        public Shelf AddShelf(Shelf shelf)
        {
            _shelves.Add(shelf);
            shelf.Id = _shelves.Count;
            return shelf;
        }

        public void DeleteBookFromShelf(ShelfBook book, int shelfId)
        {
            var shelf = _shelves.FirstOrDefault(x => x.Id == shelfId);

            if (shelf == null || !shelf.Books.Remove(book))
            {
                throw new ArgumentNullException();
            }
        }

        public void DeleteShelf(Shelf shelf)
        {
            if (!_shelves.Remove(shelf))
            {
                throw new Application.Exceptions.ShelfNotFoundException("Exception occured, shelf not found!");
            }
        }

        public Shelf GetShelfById(int id)
        {
            var shelf = _shelves.FirstOrDefault(x => x.Id == id);
            if (shelf == null)
            {
                throw new Application.Exceptions.ShelfNotFoundException("Exception occured, shelf not found!");
            }
            return shelf;
        }
    }
}
