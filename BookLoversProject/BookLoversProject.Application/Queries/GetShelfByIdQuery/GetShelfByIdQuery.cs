using BookLoversProject.Application.DTO;
using MediatR;

namespace BookLoversProject.Application.Queries.GetShelfByIdQuery
{
    public class GetShelfByIdQuery: IRequest<ShelfGetDTO>
    {
        public int Id { get; set; }
    }
}
