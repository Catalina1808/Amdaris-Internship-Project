using AutoMapper;
using BookLoversProject.Application.Interfaces;
using BookLoversProject.Application.Queries.GetUsersCount;
using MediatR;

namespace BookLoversProject.Application.Queries.GetBooksCount
{
    public class GetUsersCountQueryHandler : IRequestHandler<GetUsersCountQuery, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetUsersCountQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> Handle(GetUsersCountQuery request, CancellationToken cancellationToken)
        {
            var result = _unitOfWork.UserRepository.GetUsersCount();

            return result;
        }
    }
}
