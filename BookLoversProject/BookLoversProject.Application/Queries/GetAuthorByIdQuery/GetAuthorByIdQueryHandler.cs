using AutoMapper;
using BookLoversProject.Application.Interfaces;
using BookLoversProject.Application.Queries.GetAuthorsQuery;
using MediatR;

namespace BookLoversProject.Application.Queries.GetAuthorByIdQuery
{
    public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, AuthorDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAuthorByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AuthorDTO> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            var result = _mapper.Map<AuthorDTO>(_unitOfWork.AuthorRepository.GetAuthorByIdAsync(request.Id));
            return result;
        }
    }
}
