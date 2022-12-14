using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;
using MediatR;

namespace BookLoversProject.Application.Commands.Update.UpdateGenreCommand
{
    public class UpdateGenreCommandHandler : IRequestHandler<UpdateGenreCommand, Genre>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateGenreCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Genre> Handle(UpdateGenreCommand request, CancellationToken cancellationToken)
        {
            var toUpdate = new Genre
            {
                Id = request.Id,
                Name = request.Name
            };

            _unitOfWork.GenreRepository.UpdateGenre(toUpdate);

            await _unitOfWork.Save();

            return toUpdate;
        }
    }
}
