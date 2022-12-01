using AutoMapper;
using BookLoversProject.Application.Interfaces;
using MediatR;

namespace BookLoversProject.Application.Queries.GetReviewsByBookId
{
    public class GetReviewsByBookIdQueryHandler : IRequestHandler<GetReviewsByBookIdQuery, IEnumerable<ReviewDTO>>
    {
        public readonly IBookRepository _bookRepository;
        public readonly IMapper _mapper;

        public GetReviewsByBookIdQueryHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public Task<IEnumerable<ReviewDTO>> Handle(GetReviewsByBookIdQuery request, CancellationToken cancellationToken)
        {
            var result = _bookRepository.GetReviewsByBookId(request.BookId)
                .Select(x => _mapper.Map<ReviewDTO>(x));

            return Task.FromResult(result);
        }
    }
}
