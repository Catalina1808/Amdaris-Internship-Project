using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;
using MediatR;

namespace BookLoversProject.Application.Commands.Create.CreateUserCommand
{
    internal class CreateUserCommandHander : IRequestHandler<CreateUserCommand, User>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateUserCommandHander(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var reader = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                ImagePath = request.ImagePath,
                Email = request.Email,
                Password = request.Password
            };

            await _unitOfWork.UserRepository.AddReaderAsync(reader);
            await _unitOfWork.Save();

            return reader;
        }
    }
}
