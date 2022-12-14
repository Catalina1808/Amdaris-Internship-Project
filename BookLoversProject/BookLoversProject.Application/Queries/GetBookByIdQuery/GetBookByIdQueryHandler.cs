using AutoMapper;
using BookLoversProject.Application.DTO;
using BookLoversProject.Application.Interfaces;
using MediatR;

namespace BookLoversProject.Application.Queries.GetBookByIdQuery
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, BookGetDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetBookByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BookGetDTO> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var result = _mapper.Map<BookGetDTO>(await _unitOfWork.BookRepository.GetBookByIdAsync(request.Id));
            return result;
        }
    }
}
