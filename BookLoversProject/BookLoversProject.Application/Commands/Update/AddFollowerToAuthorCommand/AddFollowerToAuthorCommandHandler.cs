using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;
using MediatR;

namespace BookLoversProject.Application.Commands.Update.AddFollowerToAuthorCommand
{
    public class AddFollowerToAuthorCommandHandler: IRequestHandler<AddFollowerToAuthorCommand, Author>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddFollowerToAuthorCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Author> Handle(AddFollowerToAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = await _unitOfWork.AuthorRepository.GetAuthorByIdAsync(request.AuthorId);
            var user = await _unitOfWork.UserRepository.GetUserByIdAsync(request.UserId);

            if (author == null || user != null)
            {
                return null;
            }

            var userAuthorLink = new UserAuthor{ AuthorId = request.AuthorId, UserId = request.UserId };
            author.Followers.Add(userAuthorLink);

            await _unitOfWork.Save();

            return author;
        }
    }
}
