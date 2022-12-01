using BookLoversProject.Application.Exceptions;
using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly List<Book> _books;

        public BookRepository()
        {
            _books = new List<Book>
            {
                new Book()
                {
                    Id= 1,
                    Title = "title1",
                    Description= "description1"
                }
            };
        }


        public void AddGenreToBook(GenreBook genre, int bookId)
        {
            var book = _books.FirstOrDefault(x => x.Id == bookId);
            if(book != null)
            {
                book.Genres.Add(genre);
            }
            else
            {
                throw new BookNotFoundException();
            }

        }

        public void DeleteGenreFromBook(GenreBook genre, int bookId)
        {
            var book = _books.FirstOrDefault(x => x.Id == bookId);
            if (book == null || !book.Genres.Remove(genre))
            {
                throw new Exception("Genre could not be deleted!");
            }
        }

        public void AddAuthorToBook(int bookId, BookAuthor author)
        {
            var book = _books.FirstOrDefault(x => x.Id == bookId);
            if(book != null )
            {
                book.Authors.Add(author);
            }
            else
            {
                throw new BookNotFoundException();
            }
        }

        public void DeleteAuthorFromBook(int bookId, BookAuthor author)
        {
            var book = _books.FirstOrDefault(x => x.Id == bookId);
            if (book == null || !book.Authors.Remove(author))
            {
                throw new Exception("Genre could not be deleted!");
            }
        }

        public Book AddBook(Book book)
        {
            _books.Add(book);
            book.Id = _books.Count;
            return book;
        }

        public void DeleteBook(Book book)
        {
            if (!_books.Remove(book))
            {
                throw new BookNotFoundException("Exception occured, book not found!");
            }
        }

        public ICollection<Book> GetAllBooks()
        {
            return _books;
        }

        public Book GetBookById(int id)
        {
            var book = _books.FirstOrDefault(x => x.Id == id);
            if (book == null)
            {
                throw new BookNotFoundException("Exception occured, book not found!");
            }
            return book;
        }

        public ICollection<Review> GetReviewsByBookId(int bookId)
        {
            var book = _books.FirstOrDefault(x => x.Id == bookId);
            if (book == null || book.Reviews == null)
            {
                throw new ReviewNotFoundException("Exception occured, reviews not found!");
            }

            return book.Reviews;
        }

        public void AddReviewToBook(Review review, int bookId)
        {
            var book = _books.FirstOrDefault(x => x.Id == bookId);
            if (review == null || book == null)
            {
                throw new ArgumentNullException("Exception occured, review or book not defined!");
            }
            book.Reviews.Add(review);
        }

        public void DeleteReviewFromBook(Review review, int bookId)
        {
            var book = _books.FirstOrDefault(x => x.Id == bookId);
            if (book == null || !book.Reviews.Remove(review))
            {
                throw new ReviewNotFoundException("Exception occured, review not found!");
            }
        }

        public void AddShelfToBook(ShelfBook shelf, int bookId)
        {
            var book = _books.FirstOrDefault(x => x.Id == bookId);
            if (book != null)
            {
                book.Shelves.Add(shelf);
            }
            else
            {
                throw new BookNotFoundException();
            }
        }

        public void DeleteShelfFromBook(ShelfBook shelf, int bookId)
        {
            var book = _books.FirstOrDefault(x => x.Id == bookId);
            if (book == null || !book.Shelves.Remove(shelf))
            {
                throw new Exception("Genre could not be deleted!");
            }
        }
    }
}
