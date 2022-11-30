using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;
using MediatR;

namespace BookLoversProject.Application.Commands.CreateAdminCommand
{
    internal class CreateAdminCommandHandler : IRequestHandler<CreateAdminCommand, int>
    {
        private readonly IAdminRepository _adminRepository;

        public CreateAdminCommandHandler(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public Task<int> Handle(CreateAdminCommand request, CancellationToken cancellationToken)
        {
            var admin = new Admin
            {
                Email = request.Email,
                Password = request.Password
            };
            _adminRepository.AddAdmin(admin);
            return Task.FromResult(admin.Id);
        }
    }
}
