using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;
using MediatR;

namespace BookLoversProject.Application.Commands.Delete.DeleteAdminCommand
{
    public class DeleteAdminCommandHandler : IRequestHandler<DeleteAdminCommand, Admin>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteAdminCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Admin> Handle(DeleteAdminCommand request, CancellationToken cancellationToken)
        {
            var admin = await _unitOfWork.AdminRepository.GetAdminByIdAsync(request.Id);
            _unitOfWork.AdminRepository.DeleteAdmin(admin);

            await _unitOfWork.Save();

            return admin;
        }
    }
}
