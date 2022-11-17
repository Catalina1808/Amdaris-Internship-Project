using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;
using MediatR;

namespace BookLoversProject.Application.Commands.CreateBookCommand
{
    internal class CreateBookCommandHandle : IRequestHandler<CreateBookCommand, int>
    {
        private readonly IBookRepository bookRepository;

        public CreateBookCommandHandle(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = new Book
            {
                Id = request.Id,
                Title = request.Title,
                Description = request.Description,
                AuthorList = request.AuthorList,
                GenreList= request.GenreList
            };
            bookRepository.AddBook(book);
            return Task.FromResult(book.Id);
        }
    }
}
