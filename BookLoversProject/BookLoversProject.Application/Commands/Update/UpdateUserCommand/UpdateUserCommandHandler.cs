using AutoMapper;
using BookLoversProject.Application.DTO;
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
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                ImagePath = request.ImagePath,
                Email = request.Email,
                Password = request.Password
            };

            await _unitOfWork.UserRepository.GetUserByIdAsync(request.Id);
            _unitOfWork.UserRepository.UpdateUser(toUpdate);

            await _unitOfWork.Save();

            return _mapper.Map<UserGetDTO>(toUpdate);
        }
    }
}
