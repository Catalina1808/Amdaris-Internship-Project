using AutoMapper;
using BookLoversProject.Application.DTO.AdminDTOs;
using BookLoversProject.Application.Interfaces;
using MediatR;

namespace BookLoversProject.Application.Queries.GetAdminsQuery
{
    public class GetAdminsQueryHandler : IRequestHandler<GetAdminsQuery, IEnumerable<AdminGetDTO>>
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public GetAdminsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AdminGetDTO>> Handle(GetAdminsQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.AdminRepository.GetAllAdminsAsync();

            return result.Select(admin => _mapper.Map<AdminGetDTO>(admin));
        }
    }
}
