using AutoMapper;
using BookLoversProject.Application.DTO.UserDTOs;
using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;
using MediatR;

namespace BookLoversProject.Application.Commands.Create.CreateUserCommand
{
    internal class CreateUserCommandHander : IRequestHandler<CreateUserCommand, UserGetDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateUserCommandHander(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UserGetDTO> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var reader = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                ImagePath = request.ImagePath,
                Email = request.Email,
                Password = request.Password
            };

            await _unitOfWork.UserRepository.AddReaderAsync(reader);
            await _unitOfWork.Save();

            return _mapper.Map<UserGetDTO>(reader);
        }
    }
}
