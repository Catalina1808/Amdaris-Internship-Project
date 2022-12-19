using AutoMapper;
using BookLoversProject.Application.DTO;
using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;
using MediatR;

namespace BookLoversProject.Application.Commands.Create.CreateAdminCommand
{
    internal class CreateAdminCommandHandler : IRequestHandler<CreateAdminCommand, AdminGetDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateAdminCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AdminGetDTO> Handle(CreateAdminCommand request, CancellationToken cancellationToken)
        {
            var admin = new Admin
            {
                Email = request.Email,
                Password = request.Password
            };

            await _unitOfWork.AdminRepository.AddAdminAsync(admin);
            await _unitOfWork.Save();

            return _mapper.Map<AdminGetDTO>(admin);
        }
    }
}
