using AutoMapper;
using BookLoversProject.Application.DTO;
using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;
using MediatR;

namespace BookLoversProject.Application.Commands.Update.UpdateAuthorCommand
{
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, AuthorGetDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateAuthorCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AuthorGetDTO> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var toUpdate = new Author
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description
            };

            await _unitOfWork.AdminRepository.GetAdminByIdAsync(request.Id);
            _unitOfWork.AuthorRepository.UpdateAuthor(toUpdate);

            await _unitOfWork.Save();

            return _mapper.Map<AuthorGetDTO>(toUpdate);
        }
    }
}
