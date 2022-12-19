using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;
using MediatR;

namespace BookLoversProject.Application.Commands.Update.AddAuthorToBookCommand
{
    public class AddAuthorToBookCommandHandler : IRequestHandler<AddAuthorToBookCommand, Book>
    {
        public readonly IUnitOfWork _unitOfWork;

        public AddAuthorToBookCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Book> Handle(AddAuthorToBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _unitOfWork.BookRepository.GetBookByIdAsync(request.BookId);
            await _unitOfWork.AuthorRepository.GetAuthorByIdAsync(request.AuthorId);

            var bookAuthorLink = new BookAuthor { BookId = request.BookId, AuthorId = request.AuthorId };
            book.Authors.Add(bookAuthorLink);

            await _unitOfWork.Save();

            return book;
        }
    }
}
