using BookLoversProject.Application.DTO;
using MediatR;

namespace BookLoversProject.Application.Queries.GetShelvesQuery
{
    public class GetShelvesQuery: IRequest<IEnumerable<ShelfGetDTO>>
    {
    }
}
