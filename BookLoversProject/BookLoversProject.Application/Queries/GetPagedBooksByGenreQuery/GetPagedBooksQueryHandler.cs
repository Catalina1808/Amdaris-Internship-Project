using AutoMapper;
using BookLoversProject.Application.DTO.BookDTOs;
using BookLoversProject.Application.Interfaces;
using MediatR;

namespace BookLoversProject.Application.Queries.GetPagedBooksByGenreQuery
{
    public class GetPagedBooksByGenreQueryHandler : IRequestHandler<GetPagedBooksByGenreQuery, IEnumerable<BookGetDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetPagedBooksByGenreQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookGetDTO>> Handle(GetPagedBooksByGenreQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.BookRepository.GetPagedBooksByGenreAsync(request.PageNumber, request.PageSize, request.GenreId);

            return result.Select(x => _mapper.Map<BookGetDTO>(x));
        }
    }
}
