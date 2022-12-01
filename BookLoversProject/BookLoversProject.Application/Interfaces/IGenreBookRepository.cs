using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Application.Interfaces
{
    public interface IGenreBookRepository
    {
        GenreBook AddGenreBook(GenreBook genreBook);

        ICollection<GenreBook> GetAllGenreBooks();

        ICollection<GenreBook> GetGenreBooksByGenreId(int genreId);

        ICollection<GenreBook> GetGenreBooksByBookId(int bookId);

        void DeleteGenreBook(GenreBook genreBook);
    }
}
