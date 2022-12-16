using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;
using MediatR;

namespace BookLoversProject.Application.Commands.Update.UpdateAdminCommand
{
    public class UpdateAdminCommandHandler : IRequestHandler<UpdateAdminCommand, Admin>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateAdminCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Admin> Handle(UpdateAdminCommand request, CancellationToken cancellationToken)
        {
            var toUpdate = new Admin
            {
                Id = request.Id,
                Email = request.Email,
                Password = request.Password
            };

            _unitOfWork.AdminRepository.UpdateAdmin(toUpdate);

            await _unitOfWork.Save();

            return toUpdate;
        }
    }
}
