using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;
using MediatR;

namespace BookLoversProject.Application.Commands.Create.CreateShelfCommand
{
    internal class CreateShelfCommandHandler : IRequestHandler<CreateShelfCommand, Shelf>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateShelfCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Shelf> Handle(CreateShelfCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.GetUserByIdAsync(request.UserId);
            if (user == null)
            {
                return null;
            }

            var shelf = new Shelf
            {
                Name = request.Name
            };
            user.Shelves.Add(shelf);

            await _unitOfWork.ShelfRepository.AddShelfAsync(shelf);
            await _unitOfWork.Save();

            return shelf;
        }
    }
}
