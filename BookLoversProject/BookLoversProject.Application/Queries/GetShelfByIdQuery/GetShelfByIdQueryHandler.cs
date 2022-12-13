using AutoMapper;
using BookLoversProject.Application.DTO;
using BookLoversProject.Application.Interfaces;
using MediatR;

namespace BookLoversProject.Application.Queries.GetShelfByIdQuery
{
    public class GetShelfByIdQueryHandler : IRequestHandler<GetShelfByIdQuery, ShelfDTO>
    {
        public readonly IUnitOfWork _unitOfWork;
        public readonly IMapper _mapper;

        public GetShelfByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ShelfDTO> Handle(GetShelfByIdQuery request, CancellationToken cancellationToken)
        {
            var result = _mapper.Map <ShelfDTO> (await _unitOfWork.ShelfRepository.GetShelfByIdAsync(request.Id));

            return result;
        }
    }
}
