using BookLoversProject.Application.DTO;
using MediatR;

namespace BookLoversProject.Application.Queries.GetBookByIdQuery
{
    public class GetBookByIdQuery : IRequest<BookGetDTO>
    {
        public int Id { get; set; }
    }
}
