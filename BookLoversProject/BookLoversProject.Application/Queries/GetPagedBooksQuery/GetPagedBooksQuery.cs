using BookLoversProject.Application.DTO.BookDTOs;
using MediatR;

namespace BookLoversProject.Application.Queries.GetPagedBooksQuery
{
    public class GetPagedBooksQuery: IRequest<IEnumerable<BookGetDTO>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
