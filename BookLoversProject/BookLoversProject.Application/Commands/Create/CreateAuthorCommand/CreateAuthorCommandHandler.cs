using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;
using MediatR;

namespace BookLoversProject.Application.Commands.Create.CreateAuthorCommand
{
    internal class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, Author>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateAuthorCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Author> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = new Author
            {
                Name = request.Name,
                Description = request.Description,
            };

            await _unitOfWork.AuthorRepository.AddAuthorAsync(author);
            await _unitOfWork.Save();

            return author;
        }
    }
}
