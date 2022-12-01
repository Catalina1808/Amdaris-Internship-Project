using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;
using System.Net;

namespace BookLoversProject.Infrastructure.Repositories
{
    public class ShelfBookRepository : IShelfBookRepository
    {
        private readonly ICollection<ShelfBook> _shelfBooks;

        public ShelfBookRepository(ICollection<ShelfBook> shelfBooks)
        {
            _shelfBooks = shelfBooks;
        }

        public ShelfBookRepository()
        {
            _shelfBooks= new List<ShelfBook>();
        }

        public ShelfBook AddShelfBook(ShelfBook shelfBook)
        {
            _shelfBooks.Add(shelfBook);
            return shelfBook;
        }

        public void DeleteShelfBook(ShelfBook shelfBook)
        {
            if(!_shelfBooks.Remove(shelfBook))
            {
                throw new Exception("The object could not be deleted!");
            }
        }

        public ICollection<ShelfBook> GetAllShelfBooks()
        {
            return _shelfBooks;
        }

        public ICollection<ShelfBook> GetShelfBooksByBookId(int bookId)
        {
            var shelfBooks = _shelfBooks.Where(x => x.BookId == bookId).ToList();
            if(shelfBooks.Count() > 0)
            {
                return shelfBooks;
            }
            throw new Exception("There are no objects with with the given Id");
        }

        public ICollection<ShelfBook> GetShelfBooksByShelfId(int shelfId)
        {
            var shelfBooks = _shelfBooks.Where(x => x.ShelfId == shelfId).ToList();
            if (shelfBooks.Count() > 0)
            {
                return shelfBooks;
            }
            throw new Exception("There are no objects with with the given Id");
        }
    }
}
