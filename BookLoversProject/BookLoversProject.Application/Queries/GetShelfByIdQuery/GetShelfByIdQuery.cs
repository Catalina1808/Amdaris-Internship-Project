using BookLoversProject.Application.DTO.ShelfDTOs;
using MediatR;

namespace BookLoversProject.Application.Queries.GetShelfByIdQuery
{
    public class GetShelfByIdQuery: IRequest<ShelfGetDTO>
    {
        public int Id { get; set; }
    }
}
