using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;
using MediatR;

namespace BookLoversProject.Application.Commands.Update.UpdateBookCommand
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Book>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateBookCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Book> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var toUpdate = new Book
            {
                Id = request.Id,
                Title = request.Title,
                Description = request.Description
            };

            _unitOfWork.BookRepository.UpdateBook(toUpdate);

            await _unitOfWork.Save();

            return toUpdate;
        }
    }
}
