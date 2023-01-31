using AutoMapper;
using BookLoversProject.Application.DTO.UserDTOs;
using BookLoversProject.Application.Interfaces;
using MediatR;

namespace BookLoversProject.Application.Queries.GetUserByIdQuery
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserGetDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetUserByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UserGetDTO> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var result = _mapper.Map<UserGetDTO>(await _unitOfWork.UserRepository.GetUserByIdAsync(request.Id));

            return result;
        }
    }
}
