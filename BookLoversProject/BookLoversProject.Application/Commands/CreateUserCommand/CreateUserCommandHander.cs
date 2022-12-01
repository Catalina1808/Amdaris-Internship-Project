using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;
using MediatR;

namespace BookLoversProject.Application.Commands.CreateReaderCommand
{
    internal class CreateUserCommandHander : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUserRepository _readerRepository;

        public CreateUserCommandHander(IUserRepository readerRepository)
        {
            _readerRepository = readerRepository;   
        }

        public Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var reader = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                ImagePath = request.ImagePath
            };
            _readerRepository.AddReader(reader);
            return Task.FromResult(reader.Id);
        }
    }
}
