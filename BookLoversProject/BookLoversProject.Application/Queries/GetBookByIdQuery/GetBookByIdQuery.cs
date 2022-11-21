using BookLoversProject.Application.Queries.GetBooksQuery;
using MediatR;

namespace BookLoversProject.Application.Queries.GetBookByIdQuery
{
    public class GetBookByIdQuery : IRequest<BookDTO>
    {
        public int Id { get; set; }
    }
}
