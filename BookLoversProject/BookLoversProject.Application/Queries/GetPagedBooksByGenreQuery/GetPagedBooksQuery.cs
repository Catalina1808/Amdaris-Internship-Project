using BookLoversProject.Application.DTO.BookDTOs;
using MediatR;

namespace BookLoversProject.Application.Queries.GetPagedBooksByGenreQuery
{
    public class GetPagedBooksByGenreQuery: IRequest<IEnumerable<BookGetDTO>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int GenreId { get; set; }
    }
}
