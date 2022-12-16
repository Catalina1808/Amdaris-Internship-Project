using AutoMapper;
using BookLoversProject.Application.DTO;
using BookLoversProject.Application.Interfaces;
using MediatR;

namespace BookLoversProject.Application.Queries.GetShelvesQuery
{
    public class GetShelvesQueryHandler : IRequestHandler<GetShelvesQuery, IEnumerable<ShelfGetDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetShelvesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ShelfGetDTO>> Handle(GetShelvesQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.ShelfRepository.GetAllShelvesAsync();

            return result.Select(x => _mapper.Map<ShelfGetDTO>(x));
        }
    }
}
