using AutoMapper;
using BookLoversProject.Application.DTO.ReviewDTOs;
using BookLoversProject.Application.Interfaces;
using MediatR;

namespace BookLoversProject.Application.Queries.GetReviewByIdQuery
{
    public class GetReviewByIdQueryHandler : IRequestHandler<GetReviewByIdQuery, ReviewGetDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetReviewByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ReviewGetDTO> Handle(GetReviewByIdQuery request, CancellationToken cancellationToken)
        {
            var result = _mapper.Map<ReviewGetDTO>(await _unitOfWork.ReviewRepository.GetReviewByIdAsync(request.Id));

            return result;
        }
    }
}
