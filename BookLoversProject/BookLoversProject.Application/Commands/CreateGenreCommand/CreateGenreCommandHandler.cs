using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;
using MediatR;

namespace BookLoversProject.Application.Commands.CreateGenreCommand
{
    internal class CreateGenreCommandHandler : IRequestHandler<CreateGenreCommand, int>
    {
        private readonly IGenreRepository _genreRepository;

        public CreateGenreCommandHandler(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public Task<int> Handle(CreateGenreCommand request, CancellationToken cancellationToken)
        {
            var genre = new Genre
            {
                Name = request.Name
            };
            _genreRepository.AddGenre(genre);
            return Task.FromResult(genre.Id);
        }
    }
}
