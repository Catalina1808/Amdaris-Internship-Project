using AutoMapper;
using BookLoversProject.Application.Interfaces;
using MediatR;

namespace BookLoversProject.Application.Queries.GetGenresQuery
{
    public class GetGenreQueryHandler : IRequestHandler<GetGenreQuery, IEnumerable<GenreDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetGenreQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GenreDTO>> Handle(GetGenreQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.GenreRepository.GetAllGenresAsync();            

            return result.Select(x => _mapper.Map<GenreDTO>(x));
        }
    }
}
