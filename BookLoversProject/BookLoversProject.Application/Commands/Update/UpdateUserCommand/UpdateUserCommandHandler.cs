using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;
using MediatR;
using System.Reflection.PortableExecutable;

namespace BookLoversProject.Application.Commands.Update.UpdateUserCommand
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, User>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<User> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var toUpdate = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                ImagePath = request.ImagePath,
                Email = request.Email,
                Password = request.Password
            };

            _unitOfWork.UserRepository.UpdateUser(toUpdate);

            await _unitOfWork.Save();

            return toUpdate;
        }
    }
}
