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

            //one IEnumerable example
            IEnumerable<IAuthor> enumAuthors = from author in authors where author.GetType() == typeof(AccountAuthor) select author;
            Console.WriteLine(enumAuthors.ElementAt(0).Name);

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

            var bookOperationsHelper = new BooksProviderProxy();
            await bookOperationsHelper.AddBookAsync(new Admin("email", "password"),
                new Book
                {
                    Id = 2,
                    Title = "title2",
                    Description = "description2",
                    AuthorList = authors,
                    GenreList = genres
                });
            await bookOperationsHelper.ListBooksAsync();
            Console.WriteLine();
            await bookOperationsHelper.ListBookByIdAsync(book1.Id);



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
