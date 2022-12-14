using AutoMapper;
using BookLoversProject.Application.DTO;
using BookLoversProject.Application.Interfaces;
using MediatR;

namespace BookLoversProject.Application.Queries.GetGenreByIdQuery
{
    public class GetGenreByIdQueryHandler : IRequestHandler<GetGenreByIdQuery, GenreDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetGenreByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GenreDTO> Handle(GetGenreByIdQuery request, CancellationToken cancellationToken)
        {
            var result = _mapper.Map<GenreDTO>(await _unitOfWork.GenreRepository.GetGenreByIdAsync(request.Id));

            return result;
        }
    }
}
