using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;
using MediatR;

namespace BookLoversProject.Application.Commands.Create.CreateAdminCommand
{
    internal class CreateAdminCommandHandler : IRequestHandler<CreateAdminCommand, Admin>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateAdminCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Admin> Handle(CreateAdminCommand request, CancellationToken cancellationToken)
        {
            var admin = new Admin
            {
                Email = request.Email,
                Password = request.Password
            };

            await _unitOfWork.AdminRepository.AddAdminAsync(admin);
            await _unitOfWork.Save();

            return admin;
        }
    }
}
