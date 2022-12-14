using AutoMapper;
using BookLoversProject.Application.DTO;
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
            var result = await _unitOfWork.UserRepository.GetAllUsersAsync();              

            return result.Select(x => _mapper.Map<UserGetDTO>(x));
        }
    }
}
