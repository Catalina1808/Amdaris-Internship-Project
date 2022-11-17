using BookLoversProject.Application.Interfaces;
using BookLoversProject.Application.Queries.GetBooksQuery;
using BookLoversProject.Application.Commands.CreateBookCommand;
using BookLoversProject.Domain.Domain;
using BookLoversProject.Infrastructure.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BookLoversProject.Presentation
{
    public class TestClass
    {
        public static async Task Main()
        {
            NoAccountAuthor noAccountAuthor = new NoAccountAuthor("noAccount1");
            AccountAuthor accountAuthor = new AccountAuthor("emailAuthor1", "password1", "account1");
            List<IAuthor> authors = new List<IAuthor>();
            authors.Add(noAccountAuthor);
            authors.Add(accountAuthor);

            //one IEnumerable example
            IEnumerable<IAuthor> enumAuthors = from author in authors where author.GetType() == typeof(AccountAuthor) select author;

            List<Genre> genres = new List<Genre> {
                new Genre
                {
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



            //Queries and Commands test

            var diContainer = new ServiceCollection()
                .AddMediatR(typeof(IBookRepository))
                .AddScoped<IBookRepository, BookRepository>()
                .BuildServiceProvider();

            var mediator = diContainer.GetRequiredService<IMediator>();

            var bookId = await mediator.Send(new CreateBookCommand
            {
                Id = 2,
                Title = "title2",
                Description = "description2",
                AuthorList = authors,
                GenreList= genres
            });

            Console.WriteLine($"Book created with {bookId}");

            var books = await mediator.Send(new GetBooksQuery());

            foreach(var book in books)
            {
                Console.WriteLine($"{book.Id} - {book.Title} - {book.Description}");
            }

            Console.WriteLine();





            //Assignment 8 test

            //Assignment8 assignment8 = new Assignment8();
            //assignment8.CompressAndEncryptGenres(genres);

            //List<Genre> decompressedGenres = assignment8.DecompressAndDecryptGenres();

            //foreach (Genre genre in decompressedGenres)
            //{
            //    Console.WriteLine(genre.Id + " " + genre.Name);
            //}
        }
    }
}
