using BookLoversProject.Application;
using BookLoversProject.Application.Queries.GetBooksQuery;
using BookLoversProject.Application.Commands.CreateBookCommand;
using BookLoversProject.Domain.Domain;
using BookLoversProject.Infrastructure.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using BookLoversProject.Domain;
using BookLoversProject.Application.Interfaces;
using BookLoversProject.Presentation.StructuralPatterns.Proxy;
using BookLoversProject.Presentation.StructuralPatterns.Decorator;

namespace BookLoversProject.Presentation
{
    public class TestClass
    {
        public static async Task Main()
        {
            //using Author Factory
            IAuthor author1 = AuthorFactory.CreateAuthor(false, "noAccount1", "", "");
            IAuthor author2 = AuthorFactory.CreateAuthor(true, "account1", "emailAuthor1", "password1");
            List<IAuthor> authors = new List<IAuthor>();
            authors.Add(author1);
            authors.Add(author2);

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
                Description = "description2",
                AuthorList = authors,
                GenreList = genres
            };

            Book book3 = (Book)book1.Clone(); //because Book class implements ICloneable interface

            book3.Title = "title3";



            //Queries and Commands test

            //var diContainer = new ServiceCollection()
            //    .AddMediatR(typeof(IAssemblyMarker))
            //    .AddAutoMapper(typeof(IAssemblyMarker))
            //    .AddScoped<IBookRepository, BookRepository>()
            //    .BuildServiceProvider();

            //var mediator = diContainer.GetRequiredService<IMediator>();

            //var bookId = await mediator.Send(new CreateBookCommand
            //{
            //    Id = 2,
            //    Title = "title2",
            //    Description = "description2",
            //    AuthorList = authors,
            //    GenreList= genres
            //});

            //Console.WriteLine($"Book created with {bookId}");

            //var books = await mediator.Send(new GetBooksQuery());

            //foreach(var book in books)
            //{
            //    Console.WriteLine($"{book.Id} - {book.Title} - {book.Description}");
            //}

            //Console.WriteLine();

            Admin admin = new Admin("email", "password");

            //Proxy
            var bookOperationsProxy = new BooksProviderProxy();
            bookOperationsProxy.Initialize();
            await bookOperationsProxy.AddBookAsync(admin, book2);
            await bookOperationsProxy.ListBooksAsync();
            Console.WriteLine();

            await bookOperationsProxy.ListBookByIdAsync(book1.Id);
            Console.WriteLine();

            //Facade
            var bookOperationsFacade = new BookOperationsFacade();
            bookOperationsFacade.AddBook(admin, book2);
            Console.WriteLine();

            //Decorator
            IBook book = new SimpleBook();
            book = new FantasyBookDecorator(book);
            book = new MysteryBookDecorator(book);

            IBook anotherBook = new SimpleBook();
            anotherBook = new RomanceBookDecorator(anotherBook);
            anotherBook = new MysteryBookDecorator(anotherBook);

            Console.WriteLine("Book1 decorated: " + book.GetDescription());
            Console.WriteLine("Book2 decorated: " + anotherBook.GetDescription());

            Console.WriteLine();

            //Singleton test

            CompressAndEncryptSingleton singleton = CompressAndEncryptSingleton.Instance;
            singleton.CompressAndEncryptGenres(genres);

            List<Genre> decompressedGenres = singleton.DecompressAndDecryptGenres();

            foreach (Genre genre in decompressedGenres)
            {
                Console.WriteLine(genre.Id + " " + genre.Name);
            }
        }
    }
}
