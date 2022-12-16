using AutoMapper;
using BookLoversProject.Application.DTO;
using BookLoversProject.Application.Interfaces;
using MediatR;

namespace BookLoversProject.Application.Queries.GetAdminByIdQuery
{
    public class GetAdminByIdQueryHandler : IRequestHandler<GetAdminByIdQuery, AdminGetDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAdminByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AdminGetDTO> Handle(GetAdminByIdQuery request, CancellationToken cancellationToken)
        {
            var result = _mapper.Map<AdminGetDTO>(await _unitOfWork.AdminRepository.GetAdminByIdAsync(request.Id));

            return result;
        }
    }
}
