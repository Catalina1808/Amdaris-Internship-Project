using BookLoversProject.Application.DTO;
using MediatR;

namespace BookLoversProject.Application.Queries.GetBookByIdQuery
{
    public class GetBookByIdQuery : IRequest<BookDTO>
    {
        public int Id { get; set; }
    }
}
