using AutoMapper;
using BookLoversProject.Application.DTO;
using BookLoversProject.Application.Interfaces;
using MediatR;

namespace BookLoversProject.Application.Queries.GetBooksQuery
{
    public class GetBooksQueryHandler : IRequestHandler<GetBooksQuery, IEnumerable<BookGetDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetBooksQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookGetDTO>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.BookRepository.GetAllBooksAsync();

            return result.Select(x => _mapper.Map<BookGetDTO>(x));
        }
    }
}
