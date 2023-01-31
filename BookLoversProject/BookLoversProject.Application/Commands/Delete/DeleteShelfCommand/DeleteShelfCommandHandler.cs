using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;
using MediatR;

namespace BookLoversProject.Application.Commands.Delete.DeleteShelfCommand
{
    public class DeleteShelfCommandHandler : IRequestHandler<DeleteShelfCommand, Shelf>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteShelfCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Shelf> Handle(DeleteShelfCommand request, CancellationToken cancellationToken)
        {
            var shelf = await _unitOfWork.ShelfRepository.GetShelfByIdAsync(request.Id);

            _unitOfWork.ShelfRepository.DeleteShelf(shelf);

            await _unitOfWork.Save();

            return shelf;
        }
    }
}
