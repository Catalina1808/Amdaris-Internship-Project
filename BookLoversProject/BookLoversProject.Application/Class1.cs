using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Application
{
    public interface IBookRepository
    {
        Book AddBook(Book book);

        Book GetBookById(int id);

        List<Book> GetAllBooks();
    }
}