using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;
using MediatR;

namespace BookLoversProject.Application.Commands.CreateReaderCommand
{
    internal class CreateUserCommandHander : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateUserCommandHander(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var reader = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                ImagePath = request.ImagePath
            };

            await _unitOfWork.UserRepository.AddReaderAsync(reader);
            await _unitOfWork.Save();

            return reader.Id;
        }
    }
}
