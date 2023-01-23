using AutoMapper;
using BookLoversProject.Application.Interfaces;
using MediatR;

namespace BookLoversProject.Application.Queries.GetBooksCountByGenre
{
    public class GetBooksCountByGenreQueryHandler : IRequestHandler<GetBooksCountByGenreQuery, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetBooksCountByGenreQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> Handle(GetBooksCountByGenreQuery request, CancellationToken cancellationToken)
        {
            var result = _unitOfWork.BookRepository.GetBooksCountByGenre(request.GenreId);

            return result;
        }
    }
}
