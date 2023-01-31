using AutoMapper;
using BookLoversProject.Application.DTO.AuthorDTOs;
using BookLoversProject.Application.Exceptions;
using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;
using MediatR;
using System;

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

            var userAuthorLink = author.Followers
                     .SingleOrDefault(link => link.AuthorId == request.AuthorId && link.UserId == request.UserId);
            if (userAuthorLink != null)
            {
                throw new ObjectAlreadyFoundException("Exception occurred! The link between the objects already exists!");
            }

            var newLink = new UserAuthor{ AuthorId = request.AuthorId, UserId = request.UserId };
            author.Followers.Add(newLink);

            await _unitOfWork.Save();

            return _mapper.Map<AuthorGetDTO>(author);
        }
    }
}
