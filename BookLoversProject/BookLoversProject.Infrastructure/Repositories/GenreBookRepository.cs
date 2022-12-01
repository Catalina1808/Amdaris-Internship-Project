using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;
using System.Net;

namespace BookLoversProject.Infrastructure.Repositories
{
    public class GenreBookRepository : IGenreBookRepository
    {
        private readonly ICollection<GenreBook> _genreBooks;

        public GenreBookRepository(ICollection<GenreBook> genreBooks)
        {
            _genreBooks = genreBooks;
        }

        public GenreBook AddGenreBook(GenreBook genreBook)
        {
            _genreBooks.Add(genreBook);
            return genreBook;
        }

        public void DeleteGenreBook(GenreBook genreBook)
        {
            if (!_genreBooks.Remove(genreBook))
            {
                throw new Exception("The object could not be deleted!");
            }
        }

        public ICollection<GenreBook> GetAllGenreBooks()
        {
            return _genreBooks;
        }

        public ICollection<GenreBook> GetGenreBooksByBookId(int bookId)
        {
            ICollection<GenreBook> genreBooks = _genreBooks.Where(x => x.BookId == bookId).ToList();
            if(genreBooks.Count > 0)
            {
                return genreBooks;
            }
            throw new Exception("There are no objects with the given Id");
        }

        public ICollection<GenreBook> GetGenreBooksByGenreId(int genreId)
        {
            ICollection<GenreBook> genreBooks = _genreBooks.Where(x => x.GenreId == genreId).ToList();
            if (genreBooks.Count > 0)
            {
                return genreBooks;
            }
            throw new Exception("There are no objects with the given Id");
        }
    }
}
