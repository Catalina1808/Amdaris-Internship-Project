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


        public void AddGenreToBook(Genre genre, Book book)
        {
            var genreBook = new GenreBook
            {
                GenreId = genre.Id,
                Genre = genre,
                Book = book,
                BookId = book.Id
            };

            genre.Books.Add(genreBook);
            book.Genres.Add(genreBook);
        }

        public void DeleteGenreFromBook(Genre genre, Book book)
        {
            var genreBook = book.Genres.FirstOrDefault(item => item.Genre == genre);

            if (!book.Genres.Remove(genreBook))
            {
                throw new Exception("Genre not found!");
            }
        }

        public void AddAuthorToBook(Book book, Author author)
        {
            var bookAuthor = new BookAuthor
            {
                AuthorId = author.Id,
                Author = author,
                BookId = book.Id,
                Book = book
            };

            author.Books.Add(bookAuthor);
            book.Authors.Add(bookAuthor);
        }

        public void DeleteAuthorFromBook(Book book, Author author)
        {
            var bookAuthor = book.Authors.FirstOrDefault(item => item.Author == author);

            if (!book.Authors.Remove(bookAuthor))
            {
                throw new Exception("Author not found!");
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
                throw new Application.Exceptions.BookNotFoundException("Exception occured, book not found!");
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
                throw new Application.Exceptions.BookNotFoundException("Exception occured, book not found!");
            }
            return book;
        }

        public ICollection<Review> GetReviewsByBookId(int bookId)
        {
            var book = GetBookById(bookId);
            var reviews = book.Reviews;
            if (reviews == null)
            {
                throw new Application.Exceptions.ReviewNotFoundException("Exception occured, reviews not found!");
            }
            return reviews;
        }

        public void AddReviewToBook(Review review, Book book)
        {
            if (review == null)
            {
                throw new ArgumentNullException("Exception occured, review not defined!");
            }
            book.Reviews.Add(review);
        }

        public void DeleteReviewFromBook(Review review, Book book)
        {
            if (!book.Reviews.Remove(review))
            {
                throw new Application.Exceptions.ReviewNotFoundException("Exception occured, review not found!");
            }
        }
    }
}
