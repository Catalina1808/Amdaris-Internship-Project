using AutoMapper;
using BookLoversProject.Application.DTO.GenreDTOs;
using BookLoversProject.Application.Interfaces;
using MediatR;

namespace BookLoversProject.Application.Queries.GetGenreByIdQuery
{
    public class GetGenreByIdQueryHandler : IRequestHandler<GetGenreByIdQuery, GenreGetDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetGenreByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GenreGetDTO> Handle(GetGenreByIdQuery request, CancellationToken cancellationToken)
        {
            var result = _mapper.Map<GenreGetDTO>(await _unitOfWork.GenreRepository.GetGenreByIdAsync(request.Id));

            return result;
        }
    }
}
