using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Infrastructure.Repositories
{
    public class BookAuthorRepository : IBookAuthorRepository
    {
        private readonly ICollection<BookAuthor> _bookAuthors;

        public BookAuthorRepository(ICollection<BookAuthor> bookAuthors)
        {
            _bookAuthors = bookAuthors;
        }

        public BookAuthor AddBookAuthor(BookAuthor bookAuthor)
        {
            _bookAuthors.Add(bookAuthor);
            return bookAuthor;
        }

        public void DeleteBookAuthor(BookAuthor bookAuthor)
        {
            if(!_bookAuthors.Remove(bookAuthor))
            {
                throw new Exception("The object could not be deleted!");
            }
        }

        public ICollection<BookAuthor> GetAllBookAuthors()
        {
            return _bookAuthors;
        }

        public ICollection<BookAuthor> GetBookAuthorsByAuthorId(int authorId)
        {
            var bookAuthors = _bookAuthors.Where(x => x.AuthorId == authorId).ToList();
            if (bookAuthors.Count() > 0)
            {
                return bookAuthors;
            }
            throw new Exception("There are no objects with the given Id");
        }

        public ICollection<BookAuthor> GetBookAuthorsByBookId(int bookId)
        {
            var bookAuthors = _bookAuthors.Where(x => x.BookId == bookId).ToList();
            if (bookAuthors.Count() > 0)
            {
                return bookAuthors;
            }
            throw new Exception("There are no objects with the given Id");
        }
    }
}
