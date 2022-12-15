using BookLoversProject.Domain.Domain;
using BookLoversProject.Infrastructure;

namespace BookLoversProject.Presentation.IntegrationTest.Helpers
{
    public static class Utilities
    {
        public static void InitializeDbForTests(ApplicationContext db)
        {
            var author1 = new Author
            {
                Name = "Colleen Hoover",
                Description = "collen hoover description"
            };
            var author2 = new Author
            {
                Name = "Rupi Kaur",
                Description = "rupi kaur description"
            };
            var author3 = new Author
            {
                Name = "J.P. Delaney",
                Description = "jp delaney description"
            };

            db.Authors.AddRange(author1, author2, author3);

            var genre1 = new Genre
            {
                Name = "Contemporary"
            };

            var genre2 = new Genre
            {
                Name = "Poetry"
            };

            db.Genres.AddRange(genre1, genre2);

            var book = new Book
            {
                Title = "Ugly Love",
                Description = "ugly love description",
                Authors = new List<BookAuthor>() { new BookAuthor{AuthorId = 1 } },
                Genres = new List<GenreBook>() { new GenreBook { GenreId = 1} }
            };

            db.Books.Add(book);
            db.SaveChanges();

            var book2 = new Book
            {
                Title = "Verity",
                Description = "verity description",
                Authors = new List<BookAuthor>() { new BookAuthor { AuthorId = 1 } },
                Genres = new List<GenreBook>() { new GenreBook { GenreId = 1 } }
            };

            db.Books.Add(book2);
            db.SaveChanges();

            var book3 = new Book
            {
                Title = "Milk and Honey",
                Description = "milk and honey description",
                Authors = new List<BookAuthor>() { new BookAuthor { AuthorId = 2 } },
                Genres = new List<GenreBook>() { new GenreBook { GenreId = 2 } }
            };

            db.Books.Add(book3);
            db.SaveChanges();
        }
    }
}
