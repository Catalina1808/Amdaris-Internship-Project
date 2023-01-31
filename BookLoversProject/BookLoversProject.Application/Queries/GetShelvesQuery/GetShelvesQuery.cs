using BookLoversProject.Application.DTO.ShelfDTOs;
using MediatR;

namespace BookLoversProject.Application.Queries.GetShelvesQuery
{
    public class GetShelvesQuery: IRequest<IEnumerable<ShelfGetDTO>>
    {
    }
}
