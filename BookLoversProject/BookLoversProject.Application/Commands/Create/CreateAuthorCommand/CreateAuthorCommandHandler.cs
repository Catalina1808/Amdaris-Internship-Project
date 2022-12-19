using AutoMapper;
using BookLoversProject.Application.DTO;
using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;
using MediatR;

namespace BookLoversProject.Application.Commands.Create.CreateAuthorCommand
{
    internal class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, AuthorGetDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateAuthorCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AuthorGetDTO> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = new Author
            {
                Name = request.Name,
                Description = request.Description,
            };

            await _unitOfWork.AuthorRepository.AddAuthorAsync(author);
            await _unitOfWork.Save();

            return _mapper.Map<AuthorGetDTO>(author);
        }
    }
}
