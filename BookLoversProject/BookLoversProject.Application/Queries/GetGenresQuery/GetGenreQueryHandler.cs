using AutoMapper;
using BookLoversProject.Application.DTO;
using BookLoversProject.Application.Interfaces;
using MediatR;

namespace BookLoversProject.Application.Queries.GetGenresQuery
{
    public class GetGenreQueryHandler : IRequestHandler<GetGenreQuery, IEnumerable<GenreGetDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetGenreQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GenreGetDTO>> Handle(GetGenreQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.GenreRepository.GetAllGenresAsync();            

            return result.Select(x => _mapper.Map<GenreGetDTO>(x));
        }
    }
}
