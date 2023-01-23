using AutoMapper;
using BookLoversProject.Application.DTO.BookDTOs;
using BookLoversProject.Application.Interfaces;
using MediatR;

namespace BookLoversProject.Application.Queries.GetPagedBooksQuery
{
    public class GetPagedBooksQueryHandler : IRequestHandler<GetPagedBooksQuery, IEnumerable<BookGetDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetPagedBooksQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookGetDTO>> Handle(GetPagedBooksQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.BookRepository.GetPagedBooksAsync(request.PageNumber, request.PageSize);

            return result.Select(x => _mapper.Map<BookGetDTO>(x));
        }
    }
}
