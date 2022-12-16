using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;
using MediatR;

namespace BookLoversProject.Application.Commands.Update.UpdateShelfCommand
{
    public class UpdateShelfCommandHandler : IRequestHandler<UpdateShelfCommand, Shelf>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateShelfCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Shelf> Handle(UpdateShelfCommand request, CancellationToken cancellationToken)
        {
            var toUpdate = new Shelf
            {
                Id = request.Id,
                Name = request.Name
            };

            _unitOfWork.ShelfRepository.UpdateShelf(toUpdate);

            await _unitOfWork.Save();

            return toUpdate;
        }
    }
}
