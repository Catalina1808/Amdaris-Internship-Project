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
using BookLoversProject.Application.Commands.CreateAuthorCommand;
using BookLoversProject.Application.Commands.CreateBookCommand;
using BookLoversProject.Application.Commands.CreateBookAuthorCommand;
using BookLoversProject.Application.Queries.GetBooksQuery;

namespace BookLoversProject.Presentation
{
    public class TestClass
    {
        public static async Task Main()
        {
            //using User Factory
            AbstractUser user1 = UserFactory.CreateUser(true,"emailAdmin", "password");
            AbstractUser user2 = UserFactory.CreateUser(false, "emailUser", "password");


            List<BookAuthor> authors = new List<BookAuthor>();

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
                Title = "title1",
                Description = "description",
                Authors = authors,
                Genres = new List<GenreBook>()
            };
            Book book2 = new Book
            {
                Title = "title2",
                Description = "description2",
                Authors = authors,
                Genres = new List<GenreBook>()
            };

            Book book3 = (Book)book1.Clone(); //because Book class implements ICloneable interface

            book3.Title = "title3";


            //Queries and Commands test

            //var diContainer = new ServiceCollection()
            //    .AddMediatR(typeof(IAssemblyMarker))
            //    .AddAutoMapper(typeof(IAssemblyMarker))
            //    .AddScoped<IBookRepository, BookRepository>()
            //    .AddScoped<IAuthorRepository, AuthorRepository>()
            //    .AddScoped<IBookAuthorRepository, BookAuthorRepository>()
            //    .BuildServiceProvider();

            //var mediator = diContainer.GetRequiredService<IMediator>();

            //var author = new Author { Name = "author", Description = "description", Books = new List<BookAuthor>(), Followers = new List<UserAuthor>() };
            //var authorId = await mediator.Send(new CreateAuthorCommand { Name = author.Name, Description = author.Description, Books = author.Books, Followers = author.Followers });
            //var bookId = await mediator.Send(new CreateBookCommand { Title = book1.Title, Description = book1.Description, AuthorList = book1.Authors });
            //var bookAuthor = await mediator.Send(new CreateBookAuthorCommand { AuthorId = authorId, Author = author, BookId = bookId, Book = book1 });

            //Console.WriteLine("created author with id=" + authorId + " and book with id=" + bookId + " and bookAuthor");

            //var books = await mediator.Send(new GetBooksQuery());
            //foreach (var b in books)
            //{
            //    Console.WriteLine("Book with id:" + b.Id);
            //    foreach (var authorb in b.Authors)
            //    {
            //        Console.WriteLine(authorb.AuthorId + " " + authorb.Author.Name);
            //    }
            //}


            Admin admin = new Admin { Email = "email", Password = "password" };

            //Proxy
            var bookOperationsProxy = new BooksProviderProxy();
            bookOperationsProxy.Initialize();
            await bookOperationsProxy.AddBookAsync(admin, book2);
            await bookOperationsProxy.ListBooksAsync();
            Console.WriteLine();

            await bookOperationsProxy.ListBookByIdAsync(1);
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
