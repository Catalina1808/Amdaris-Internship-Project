using BookLoversProject.Application.Commands.Create.CreateBookCommand;
using BookLoversProject.Application.Interfaces;
using BookLoversProject.Application;
using BookLoversProject.Domain.Domain;
using BookLoversProject.Infrastructure.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using BookLoversProject.Application.Queries.GetBooksQuery;
using BookLoversProject.Application.Queries.GetBookByIdQuery;

namespace BookLoversProject.Presentation.Structural_Patterns.Proxy
{
    public class BooksProvider : IBooksProvider
    {
        private ServiceProvider diContainer;
        private IMediator mediator;

        public void Initialize()
        {
            diContainer = new ServiceCollection()
               .AddMediatR(typeof(IAssemblyMarker))
               .AddAutoMapper(typeof(IAssemblyMarker))
               .AddScoped<IBookRepository, BookRepository>()
               .BuildServiceProvider();

            mediator = diContainer.GetRequiredService<IMediator>();
        }

        public bool IsBookValid(Book book)
        {
            if(book.Title != null && book.Authors.Count() > 0 && book.Genres.Count() > 0)
            {
                return true;
            }

            return false;
        }

        public async Task AddBookAsync(AbstractUser user, Book book)
        {
                var bookId = await mediator.Send(new CreateBookCommand
                {
                    Title = book.Title,
                    Description = book.Description
                });

                Console.WriteLine($"Book created with {bookId}");
        }

        public async Task ListBookByIdAsync(int id)
        {
            var book = await mediator.Send(new GetBookByIdQuery
            {
                Id = id
            });
            Console.WriteLine($"{book.Id} - {book.Title} - {book.Description}");
        }

        public async Task ListBooksAsync()
        {
            var books = await mediator.Send(new GetBooksQuery());

            foreach (var book in books)
            {
                Console.WriteLine($"{book.Id} - {book.Title} - {book.Description}");
            }
        }

    }
}
