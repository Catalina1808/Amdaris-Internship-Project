using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;
using MediatR;

namespace BookLoversProject.Application.Commands.Update.AddBookToShelfCommand
{
    public class AddBookToShelfCommandHandler : IRequestHandler<AddBookToShelfCommand, Shelf>
    {
        public readonly IUnitOfWork _unitOfWork;

        public AddBookToShelfCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Shelf> Handle(AddBookToShelfCommand request, CancellationToken cancellationToken)
        {
            var book = await _unitOfWork.BookRepository.GetBookByIdAsync(request.BookId);
            var shelf = await _unitOfWork.ShelfRepository.GetShelfByIdAsync(request.ShelfId);

            var shelfBookLink = new ShelfBook { BookId = request.BookId, ShelfId = request.ShelfId };
            shelf.Books.Add(shelfBookLink);

            await _unitOfWork.Save();

            return shelf;
        }
    }
}
