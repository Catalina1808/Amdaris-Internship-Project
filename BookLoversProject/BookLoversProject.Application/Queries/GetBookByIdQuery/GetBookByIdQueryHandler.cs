using AutoMapper;
using BookLoversProject.Application.Interfaces;
using BookLoversProject.Application.Queries.GetBooksQuery;
using MediatR;

namespace BookLoversProject.Application.Queries.GetBookByIdQuery
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, BookDTO>
    {
        private readonly IBookRepository _repository;
        private readonly IMapper _mapper;

        public GetBookByIdQueryHandler(IBookRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public Task<BookDTO> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var result = _mapper.Map<BookDTO>(_repository.GetBookById(request.Id));
            return Task.FromResult(result);
        }
    }
}
