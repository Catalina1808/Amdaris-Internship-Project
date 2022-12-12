using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;
using MediatR;

namespace BookLoversProject.Application.Commands.CreateShelfCommand
{
    internal class CreateShelfCommandHandler : IRequestHandler<CreateShelfCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateShelfCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateShelfCommand request, CancellationToken cancellationToken)
        {
            var shelf = new Shelf
            {
                Name = request.Name
            };

            await _unitOfWork.ShelfRepository.AddShelfAsync(shelf);
            await _unitOfWork.Save();

            return shelf.Id;
        }
    }
}
