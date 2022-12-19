using BookLoversProject.Application.DTO.AdminDTOs;
using MediatR;

namespace BookLoversProject.Application.Queries.GetAdminByIdQuery
{
    public class GetAdminByIdQuery: IRequest<AdminGetDTO>
    {
        public int Id { get; set; }
    }
}
