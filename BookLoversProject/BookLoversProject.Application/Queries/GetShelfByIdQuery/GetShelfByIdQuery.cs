using BookLoversProject.Application.DTO;
using MediatR;

namespace BookLoversProject.Application.Queries.GetShelfByIdQuery
{
    public class GetShelfByIdQuery: IRequest<ShelfDTO>
    {
        public int Id { get; set; }
    }
}
