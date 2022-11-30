using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;
using MediatR;

namespace BookLoversProject.Application.Commands.CreateShelfCommand
{
    internal class CreateShelfCommandHandler : IRequestHandler<CreateShelfCommand, int>
    {
        private readonly IShelfRepository _shelfRepository;

        public CreateShelfCommandHandler(IShelfRepository shelfRepository)
        {
            _shelfRepository = shelfRepository;
        }

        public Task<int> Handle(CreateShelfCommand request, CancellationToken cancellationToken)
        {
            var shelf = new Shelf
            {
                Name = request.Name
            };
            _shelfRepository.AddShelf(shelf);
            return Task.FromResult(shelf.Id);
        }
    }
}
