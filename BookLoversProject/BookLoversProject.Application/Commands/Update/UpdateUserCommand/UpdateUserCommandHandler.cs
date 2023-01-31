using AutoMapper;
using BookLoversProject.Application.DTO.UserDTOs;
using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;
using MediatR;
using System.Reflection.PortableExecutable;

namespace BookLoversProject.Application.Commands.Update.UpdateUserCommand
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UserGetDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UserGetDTO> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var toUpdate = new User
            {   Id= request.Id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                ImagePath = request.ImagePath,
                Email = request.Email,
                Password = request.Password,
                UserName = request.UserName,
            };

            await _unitOfWork.UserRepository.UpdateUserAsync(toUpdate);

            await _unitOfWork.Save();

            return _mapper.Map<UserGetDTO>(toUpdate);
        }
    }
}
