using BookLoversProject.Application.DTO.BookDTOs;
using MediatR;

namespace BookLoversProject.Application.Queries.GetBookByIdQuery
{
    public class GetBookByIdQuery : IRequest<BookGetDTO>
    {
        public int Id { get; set; }
    }
}
