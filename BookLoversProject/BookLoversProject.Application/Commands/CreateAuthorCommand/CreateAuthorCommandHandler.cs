using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;
using MediatR;

namespace BookLoversProject.Application.Commands.CreateAuthorCommand
{
    internal class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateAuthorCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = new Author
            {
                Name = request.Name,
                Description = request.Description,
                Books = request.Books,
                Followers = request.Followers
            };

            await _unitOfWork.AuthorRepository.AddAuthorAsync(author);
            await _unitOfWork.Save();

            return author.Id;
        }
    }
}
