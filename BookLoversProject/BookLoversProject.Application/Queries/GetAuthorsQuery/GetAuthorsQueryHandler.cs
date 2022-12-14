using AutoMapper;
using BookLoversProject.Application.DTO;
using BookLoversProject.Application.Interfaces;
using MediatR;

namespace BookLoversProject.Application.Queries.GetAuthorsQuery
{
    public class GetAuthorsQueryHandler : IRequestHandler<GetAuthorsQuery, IEnumerable<AuthorGetDTO>>
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public GetAuthorsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AuthorGetDTO>> Handle(GetAuthorsQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.AuthorRepository.GetAllAuthorsAsync();

            return result.Select(x => _mapper.Map<AuthorGetDTO>(x));
        }
    }
}
