using BookLoversProject.Application.DTO.AdminDTOs;
using MediatR;

namespace BookLoversProject.Application.Queries.GetAdminsQuery
{
    public class GetAdminsQuery: IRequest<IEnumerable<AdminGetDTO>>
    {
    }
}
