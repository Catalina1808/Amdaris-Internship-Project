using BookLoversProject.Application.DTO.UserDTOs;
using MediatR;

namespace BookLoversProject.Application.Queries.GetUsersQuery
{
    public class GetUsersQuery : IRequest<IEnumerable<UserGetDTO>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
