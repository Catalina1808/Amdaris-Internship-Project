using AutoMapper;
using BookLoversProject.Application.Interfaces;
using MediatR;

namespace BookLoversProject.Application.Queries.GetBooksQuery
{
    public class GetBooksQueryHandler : IRequestHandler<GetBooksQuery, IEnumerable<BookDTO>>
    {
        private readonly IBookRepository _repository;
        private readonly IMapper _mapper;

        public GetBooksQueryHandler(IBookRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public Task<IEnumerable<BookDTO>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
        {
            var result = _repository.GetAllBooks()
                .Select(x => _mapper.Map<BookDTO>(x));
            return Task.FromResult(result);
        }
    }
}
