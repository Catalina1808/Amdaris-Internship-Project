using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;
using MediatR;

namespace BookLoversProject.Application.Commands.Create.CreateGenreCommand
{
    internal class CreateGenreCommandHandler : IRequestHandler<CreateGenreCommand, Genre>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateGenreCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Genre> Handle(CreateGenreCommand request, CancellationToken cancellationToken)
        {
            var genre = new Genre
            {
                Name = request.Name
            };

            await _unitOfWork.GenreRepository.AddGenreAsync(genre);
            await _unitOfWork.Save();

            return genre;
        }
    }
}
