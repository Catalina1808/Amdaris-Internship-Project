using AutoMapper;
using BookLoversProject.Application.Interfaces;
using MediatR;

namespace BookLoversProject.Application.Queries.GetGenresQuery
{
    public class GetGenreQueryHandler : IRequestHandler<GetGenreQuery, IEnumerable<GenreDTO>>
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;

        public GetGenreQueryHandler(IGenreRepository genreRepository, IMapper mapper)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        Task<IEnumerable<GenreDTO>> IRequestHandler<GetGenreQuery, IEnumerable<GenreDTO>>.Handle(GetGenreQuery request, CancellationToken cancellationToken)
        {
            var result = _genreRepository.GetAllGenres()
                .Select(x => _mapper.Map<GenreDTO>(x));

            return Task.FromResult(result);
        }
    }
}
