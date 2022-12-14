using AutoMapper;
using BookLoversProject.Application.DTO;
using BookLoversProject.Application.Interfaces;
using MediatR;

namespace BookLoversProject.Application.Queries.GetShelfByIdQuery
{
    public class GetShelfByIdQueryHandler : IRequestHandler<GetShelfByIdQuery, ShelfGetDTO>
    {
        public readonly IUnitOfWork _unitOfWork;
        public readonly IMapper _mapper;

        public GetShelfByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ShelfGetDTO> Handle(GetShelfByIdQuery request, CancellationToken cancellationToken)
        {
            var result = _mapper.Map <ShelfGetDTO> (await _unitOfWork.ShelfRepository.GetShelfByIdAsync(request.Id));

            return result;
        }
    }
}
