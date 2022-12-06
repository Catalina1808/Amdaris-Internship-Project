using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;
using MediatR;

namespace BookLoversProject.Application.Commands.CreateAdminCommand
{
    internal class CreateAdminCommandHandler : IRequestHandler<CreateAdminCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateAdminCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateAdminCommand request, CancellationToken cancellationToken)
        {
            var admin = new Admin
            {
                Email = request.Email,
                Password = request.Password
            };

            await _unitOfWork.AdminRepository.AddAdmin(admin);
            await _unitOfWork.Save();

            return admin.Id;
        }
    }
}
