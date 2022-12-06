using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;
using MediatR;

namespace BookLoversProject.Application.Commands.CreateBookCommand
{
    internal class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateBookCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = new Book
            {
                Title = request.Title,
                Description = request.Description,
                Authors = request.AuthorList,
                Genres= request.GenreList
            };

            await _unitOfWork.BookRepository.AddBook(book);
            await _unitOfWork.Save();

            return book.Id;
        }
    }
}
