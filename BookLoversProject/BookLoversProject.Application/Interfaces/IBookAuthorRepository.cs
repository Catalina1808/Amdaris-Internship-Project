using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Application.Interfaces
{
    public interface IBookAuthorRepository
    {
        BookAuthor AddBookAuthor(BookAuthor bookAuthor);

        ICollection<BookAuthor> GetAllBookAuthors();

        ICollection<BookAuthor> GetBookAuthorsByBookId(int bookId);

        ICollection<BookAuthor> GetBookAuthorsByAuthorId(int authorId);

        void DeleteBookAuthor(BookAuthor bookAuthor);
    }
}
