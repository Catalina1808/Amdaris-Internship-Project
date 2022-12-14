using BookLoversProject.Application.DTO;
using MediatR;

namespace BookLoversProject.Application.Queries.GetUserByIdQuery
{
    public class GetUserByIdQuery : IRequest<UserGetDTO>
    {
        public int Id { get; set; }
    }
}
