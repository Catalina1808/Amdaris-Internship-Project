using BookLoversProject.Application.DTO;
using MediatR;

namespace BookLoversProject.Application.Queries.GetUsersQuery
{
    public class GetUsersQuery : IRequest<IEnumerable<UserGetDTO>>
    {
    }
}
