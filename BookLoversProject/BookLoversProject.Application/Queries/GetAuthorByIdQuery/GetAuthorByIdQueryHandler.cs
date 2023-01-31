using AutoMapper;
using BookLoversProject.Application.DTO.AuthorDTOs;
using BookLoversProject.Application.Interfaces;
using MediatR;

namespace BookLoversProject.Application.Queries.GetAuthorByIdQuery
{
    public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, AuthorGetDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAuthorByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AuthorGetDTO> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            var result = _mapper.Map<AuthorGetDTO>(await _unitOfWork.AuthorRepository.GetAuthorByIdAsync(request.Id));
            return result;
        }
    }
}
