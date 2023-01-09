using BookLoversProject.Application.DTO.ShelfDTOs;
using MediatR;

namespace BookLoversProject.Application.Queries.GetShelvesByUserIdQuery
{
    public class GetShelvesByUserIdQuery : IRequest<IEnumerable<ShelfGetDTO>>
    {
        public int UserId { get; set; }
    }
}