using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;
using MediatR;

namespace BookLoversProject.Application.Commands.CreateGenreCommand
{
    internal class CreateGenreCommandHandler : IRequestHandler<CreateGenreCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateGenreCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateGenreCommand request, CancellationToken cancellationToken)
        {
            var genre = new Genre
            {
                Name = request.Name
            };

            await _unitOfWork.GenreRepository.AddGenreAsync(genre);
            await _unitOfWork.Save();

            return genre.Id;
        }
    }
}
