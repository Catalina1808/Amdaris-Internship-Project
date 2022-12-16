using BookLoversProject.Application.DTO;
using MediatR;

namespace BookLoversProject.Application.Queries.GetAdminsQuery
{
    public class GetAdminsQuery: IRequest<IEnumerable<AdminGetDTO>>
    {
    }
}
