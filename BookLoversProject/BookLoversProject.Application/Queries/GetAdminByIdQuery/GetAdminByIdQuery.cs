using BookLoversProject.Application.DTO;
using MediatR;

namespace BookLoversProject.Application.Queries.GetAdminByIdQuery
{
    public class GetAdminByIdQuery: IRequest<AdminGetDTO>
    {
        public int Id { get; set; }
    }
}
