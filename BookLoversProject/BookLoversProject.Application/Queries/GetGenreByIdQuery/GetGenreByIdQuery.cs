using BookLoversProject.Application.DTO;
using MediatR;

namespace BookLoversProject.Application.Queries.GetGenreByIdQuery
{
    public class GetGenreByIdQuery : IRequest<GenreDTO>
    {
        public int Id { get; set; }
    }
}
