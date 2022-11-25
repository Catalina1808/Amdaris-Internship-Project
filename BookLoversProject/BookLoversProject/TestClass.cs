using BookLoversProject.Application;
using BookLoversProject.Domain.Domain;
using BookLoversProject.Infrastructure.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using BookLoversProject.Domain;
using BookLoversProject.Application.Interfaces;
using BookLoversProject.Presentation.StructuralPatterns.Proxy;
using BookLoversProject.Presentation.StructuralPatterns.Decorator;
using BookLoversProject.Application.Queries.GetBookByIdQuery;

namespace BookLoversProject.Presentation
{
    public class TestClass
    {
        public static async Task Main()
        {
            //using User Factory
            IUser user1 = UserFactory.CreateUser(true, "author", "email", "password");
            IUser user2 = UserFactory.CreateUser(false, "user", "email", "password");


            List<Author> authors = new List<Author>();

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

            var diContainer = new ServiceCollection()
                .AddMediatR(typeof(IAssemblyMarker))
                .AddAutoMapper(typeof(IAssemblyMarker))
                .AddScoped<IBookRepository, BookRepository>()
                .BuildServiceProvider();

            var mediator = diContainer.GetRequiredService<IMediator>();

            var bookById = await mediator.Send(new GetBookByIdQuery { Id = 1});       


            Admin admin = new Admin { Email = "email", Password = "password" };


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
