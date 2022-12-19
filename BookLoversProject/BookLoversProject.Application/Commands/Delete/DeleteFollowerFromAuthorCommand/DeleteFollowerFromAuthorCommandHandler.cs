using AutoMapper;
using BookLoversProject.Application.DTO.AuthorDTOs;
using BookLoversProject.Application.Exceptions;
using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;
using MediatR;

namespace BookLoversProject.Application.Commands.Delete.DeleteFollowerFromAuthorCommand
{
    public class DeleteFollowerFromAuthorCommandHandler : IRequestHandler<DeleteFollowerFromAuthorCommand, AuthorGetDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        public readonly IMapper _mapper;

        public DeleteFollowerFromAuthorCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AuthorGetDTO> Handle(DeleteFollowerFromAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = await _unitOfWork.AuthorRepository.GetAuthorByIdAsync(request.AuthorId);
            await _unitOfWork.UserRepository.GetUserByIdAsync(request.UserId);

            var userAuthorLink = author.Followers.SingleOrDefault(link => link.AuthorId == request.AuthorId && link.UserId == request.UserId);

            if (userAuthorLink == null)
            {
                throw new ObjectNotFoundException("Exception occurred! The link between the objects does not exist!");
            }
            author.Followers.Remove(userAuthorLink);

            await _unitOfWork.Save();

            return _mapper.Map<AuthorGetDTO>(author);
        }
    }
}
