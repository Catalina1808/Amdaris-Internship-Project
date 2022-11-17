using MediatR;

namespace BookLoversProject.Application.Queries.GetBooksQuery
{
    public class GetBooksQuery: IRequest<IEnumerable<BookDTO>>
    {
    }
}
