using AutoMapper;
using BookLoversProject.Application.DTO.AdminDTOs;
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

            await _unitOfWork.AdminRepository.UpdateAdminAsync(toUpdate);

            await _unitOfWork.Save();

            return _mapper.Map<AdminGetDTO>(toUpdate);
        }
    }
}
