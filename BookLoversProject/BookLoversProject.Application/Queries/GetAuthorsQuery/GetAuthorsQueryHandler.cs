using AutoMapper;
using BookLoversProject.Application.Interfaces;
using MediatR;

namespace BookLoversProject.Application.Queries.GetAuthorsQuery
{
    public class GetAuthorsQueryHandler : IRequestHandler<GetAuthorsQuery, IEnumerable<AuthorDTO>>
    {
        private IAuthorRepository _authorRepository;
        private IMapper _mapper;

        public GetAuthorsQueryHandler(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public Task<IEnumerable<AuthorDTO>> Handle(GetAuthorsQuery request, CancellationToken cancellationToken)
        {
            var result = _authorRepository.GetAllAuthors()
                .Select(x => _mapper.Map<AuthorDTO>(x));

            return Task.FromResult(result);
        }
    }
}
