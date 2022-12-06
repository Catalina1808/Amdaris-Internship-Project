using AutoMapper;
using BookLoversProject.Application.Interfaces;
using BookLoversProject.Application.Queries.GetUsersQuery;
using MediatR;

namespace BookLoversProject.Application.Queries.GetUserByIdQuery
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetUserByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UserDTO> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var result = _mapper.Map<UserDTO>(await _unitOfWork.UserRepository.GetUserById(request.Id));

            return result;
        }
    }
}
