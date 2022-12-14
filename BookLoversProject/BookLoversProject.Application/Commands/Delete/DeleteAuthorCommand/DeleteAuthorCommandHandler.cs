using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;
using MediatR;

namespace BookLoversProject.Application.Commands.Delete.DeleteAuthorCommand
{
    public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand, Author>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteAuthorCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Author> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = await _unitOfWork.AuthorRepository.GetAuthorByIdAsync(request.Id);

             _unitOfWork.AuthorRepository.DeleteAuthor(author);

            await _unitOfWork.Save();

            return author;
        }
    }
}
