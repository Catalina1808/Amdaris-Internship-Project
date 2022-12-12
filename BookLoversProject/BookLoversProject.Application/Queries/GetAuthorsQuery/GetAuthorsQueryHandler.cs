using AutoMapper;
using BookLoversProject.Application.Interfaces;
using MediatR;

namespace BookLoversProject.Application.Queries.GetAuthorsQuery
{
    public class GetAuthorsQueryHandler : IRequestHandler<GetAuthorsQuery, IEnumerable<AuthorDTO>>
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public GetAuthorsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AuthorDTO>> Handle(GetAuthorsQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.AuthorRepository.GetAllAuthorsAsync();

            return result.Select(x => _mapper.Map<AuthorDTO>(x));
        }
    }
}
