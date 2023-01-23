using AutoMapper;
using BookLoversProject.Application.DTO.UserDTOs;
using BookLoversProject.Application.Interfaces;
using MediatR;

namespace BookLoversProject.Application.Queries.GetUsersQuery
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IEnumerable<UserGetDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetUsersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserGetDTO>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.UserRepository.GetAllUsersAsync(request.PageNumber, request.PageSize);

            return result.Select(x => _mapper.Map<UserGetDTO>(x));
        }
    }
}
