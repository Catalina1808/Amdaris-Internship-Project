using AutoMapper;
using BookLoversProject.Application.DTO.BookDTOs;
using BookLoversProject.Application.Interfaces;
using MediatR;

namespace BookLoversProject.Application.Queries.GetBooksCount
{
    public class GetBooksCountQueryHandler : IRequestHandler<GetBooksCountQuery, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetBooksCountQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> Handle(GetBooksCountQuery request, CancellationToken cancellationToken)
        {
            var result = _unitOfWork.BookRepository.GetBooksCount();

            return result;
        }
    }
}
