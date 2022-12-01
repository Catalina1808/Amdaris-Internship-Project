using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;
using MediatR;

namespace BookLoversProject.Application.Commands.CreateBookAuthorCommand
{
    public class CreateBookAuthorCommandHandle : IRequestHandler<CreateBookAuthorCommand, BookAuthor>
    {
        private readonly IBookAuthorRepository _bookAuthorRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;

        public CreateBookAuthorCommandHandle(IBookAuthorRepository bookAuthorRepository, IBookRepository bookRepository, IAuthorRepository authorRepository)
        {
            _bookAuthorRepository = bookAuthorRepository;
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
        }

        public Task<BookAuthor> Handle(CreateBookAuthorCommand request, CancellationToken cancellationToken)
        {
           var result = _bookAuthorRepository.AddBookAuthor(
                new BookAuthor
                {
                    AuthorId = request.AuthorId,
                    BookId = request.BookId,
                    Author = request.Author,
                    Book = request.Book,
                });

           _authorRepository.AddBookToAuthor(result.AuthorId, result);
           _bookRepository.AddAuthorToBook(result.BookId, result);

           return Task.FromResult(result);
        }
    }
}
