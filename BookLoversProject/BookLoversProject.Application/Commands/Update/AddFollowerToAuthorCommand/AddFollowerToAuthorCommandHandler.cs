using AutoMapper;
using BookLoversProject.Application.DTO.AuthorDTOs;
using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;
using MediatR;

namespace BookLoversProject.Application.Commands.Update.AddFollowerToAuthorCommand
{
    public class AddFollowerToAuthorCommandHandler: IRequestHandler<AddFollowerToAuthorCommand, AuthorGetDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        public readonly IMapper _mapper;

        public AddFollowerToAuthorCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AuthorGetDTO> Handle(AddFollowerToAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = await _unitOfWork.AuthorRepository.GetAuthorByIdAsync(request.AuthorId);
            await _unitOfWork.UserRepository.GetUserByIdAsync(request.UserId);

            var userAuthorLink = new UserAuthor{ AuthorId = request.AuthorId, UserId = request.UserId };
            author.Followers.Add(userAuthorLink);

            await _unitOfWork.Save();

            return _mapper.Map<AuthorGetDTO>(author);
        }
    }
}
