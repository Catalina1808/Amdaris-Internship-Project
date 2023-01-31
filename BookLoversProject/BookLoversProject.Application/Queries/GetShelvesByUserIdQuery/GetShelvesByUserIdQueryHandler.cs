using AutoMapper;
using BookLoversProject.Application.DTO.ShelfDTOs;
using BookLoversProject.Application.Interfaces;
using MediatR;

namespace BookLoversProject.Application.Queries.GetShelvesByUserIdQuery
{
    public class GetShelvesByUserIdQueryHandler : IRequestHandler<GetShelvesByUserIdQuery, IEnumerable<ShelfGetDTO>>
    {
        public readonly IUnitOfWork _unitOfWork;
        public readonly IMapper _mapper;

        public GetShelvesByUserIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ShelfGetDTO>> Handle(GetShelvesByUserIdQuery request, CancellationToken cancellationToken)
        {
            var shelves = await _unitOfWork.ShelfRepository.GetAllShelvesAsync();
            var result = shelves.Where(shelf => shelf.UserId == request.UserId);

            return result.Select(x => _mapper.Map<ShelfGetDTO>(x));
        }
     }
}
