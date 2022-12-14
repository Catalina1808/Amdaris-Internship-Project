using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;
using MediatR;

namespace BookLoversProject.Application.Commands.Delete.DeleteGenreCommand
{
    public class DeleteGenreCommandHandler : IRequestHandler<DeleteGenreCommand, Genre>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteGenreCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Genre> Handle(DeleteGenreCommand request, CancellationToken cancellationToken)
        {
            var genre = await _unitOfWork.GenreRepository.GetGenreByIdAsync(request.Id);

            _unitOfWork.GenreRepository.DeleteGenre(genre);

            await _unitOfWork.Save();

            return genre;
        }
    }
}
