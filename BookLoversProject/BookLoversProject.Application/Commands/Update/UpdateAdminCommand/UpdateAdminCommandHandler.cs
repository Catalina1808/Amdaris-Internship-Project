using AutoMapper;
using BookLoversProject.Application.DTO;
using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;
using MediatR;

namespace BookLoversProject.Application.Commands.Update.UpdateAdminCommand
{
    public class UpdateAdminCommandHandler : IRequestHandler<UpdateAdminCommand, AdminGetDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateAdminCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AdminGetDTO> Handle(UpdateAdminCommand request, CancellationToken cancellationToken)
        {
            var toUpdate = new Admin
            {
                Id = request.Id,
                Email = request.Email,
                Password = request.Password
            };

            _unitOfWork.AdminRepository.UpdateAdmin(toUpdate);

            await _unitOfWork.Save();

            return _mapper.Map<AdminGetDTO>(toUpdate);
        }
    }
}
