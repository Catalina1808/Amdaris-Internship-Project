using BookLoversProject.Domain.Domain;
using System.IO;
using System.IO.Compression;
using System.IO.Pipes;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;

namespace BookLoversProject
{
    public class TestClass
    {
        public static void Main()
        {
            NoAccountAuthor noAccountAuthor = new NoAccountAuthor
            {
                Id = 1,
                Name = "noAccount1",
                Followers = new List<User>()
            };
            AccountAuthor accountAuthor = new AccountAuthor
            {
                Id = 1,
                Email = "emailAuthor1",
                Password = "password1",
                Name = "account1",
                Followers = new List<User>()
            };
            List<IAuthor> authors = new List<IAuthor>();
            authors.Add(noAccountAuthor);
            authors.Add(accountAuthor);

            //one IEnumerable example
            IEnumerable<IAuthor> enumAuthors = from author in authors where (author.GetType() == typeof(AccountAuthor)) select author;
            //foreach (IAuthor author in enumAuthors)
            //{
            //    Console.WriteLine(author.Name);
            //}

            List<Genre> genres = new List<Genre> {
                new Genre
                {
                    Id= 1,
                    Name= "Drama",
                },
                new Genre
                {
                    Id= 2,
                    Name= "Thriller",
                },
                new Genre
                {
                    Id= 3,
                    Name= "Fantasy",
                }
            };

            Book book1 = new Book
            {
                Id = 1,
                Title = "title1",
                Description = "description",
                AuthorList = authors,
                GenreList = genres
            };
            Book book2 = new Book
            {
                Id = 2,
                Title = "title2",
                Description = "description",
                AuthorList = authors,
                GenreList = genres
            };

            Book book3 = (Book)book1.Clone(); //because Book class implements ICloneable interface
            Book book4 = book2;

            book3.Title = "title3";
            book4.Title = "title4";

            List<Book> books = new List<Book> { book1, book2, book3, book4 };


            //Assignment 8 test

            Assignment8.CompressAndEncryptGenres(genres);

            List<Genre> decompressedGenres = Assignment8.DecompressAndDecryptGenres();

            foreach (Genre genre in decompressedGenres)
            {
                Console.WriteLine(genre.Id + " " + genre.Name);
            }
        }
    }
}
