using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Application.Repositories
{
    public class BookRepository : IBookRepository
    {
        private List<Book> books;

        public BookRepository()
        {
            books = new List<Book>();
        }

        public Book AddBook(Book book)
        {
            books.Add(book);
            return book;
        }

        public List<Book> GetAllBooks()
        {
            return books;
        }

        public Book GetBookById(int id)
        {
            return books.FirstOrDefault(x => x.Id == id);
        }
    }
}
