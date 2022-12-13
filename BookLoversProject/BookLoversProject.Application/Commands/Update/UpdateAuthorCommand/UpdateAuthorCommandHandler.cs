using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;
using MediatR;

namespace BookLoversProject.Application.Commands.Update.UpdateAuthorCommand
{
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, Author>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateAuthorCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Author> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var toUpdate = new Author
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description
            };

            _unitOfWork.AuthorRepository.UpdateAuthor(toUpdate);

            await _unitOfWork.Save();

            return toUpdate;
        }
    }
}
