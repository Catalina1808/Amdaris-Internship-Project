using AutoMapper;
using BookLoversProject.Application.DTO;
using BookLoversProject.Application.Interfaces;
using MediatR;

namespace BookLoversProject.Application.Queries.GetReviewsByBookId
{
    public class GetReviewsByBookIdQueryHandler : IRequestHandler<GetReviewsByBookIdQuery, IEnumerable<ReviewDTO>>
    {
        public readonly IUnitOfWork _unitOfWork;
        public readonly IMapper _mapper;

        public GetReviewsByBookIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ReviewDTO>> Handle(GetReviewsByBookIdQuery request, CancellationToken cancellationToken)
        {
            var result = _unitOfWork.BookRepository.GetReviewsByBookIdAsync(request.BookId).Result
                .Select(x => _mapper.Map<ReviewDTO>(x));

            return result;
        }
    }
}
