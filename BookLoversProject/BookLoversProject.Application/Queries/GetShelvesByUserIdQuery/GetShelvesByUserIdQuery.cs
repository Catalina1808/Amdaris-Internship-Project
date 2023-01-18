using BookLoversProject.Application.DTO.ShelfDTOs;
using MediatR;

namespace BookLoversProject.Application.Queries.GetShelvesByUserIdQuery
{
    public class GetShelvesByUserIdQuery : IRequest<IEnumerable<ShelfGetDTO>>
    {
        public string UserId { get; set; }
    }
}