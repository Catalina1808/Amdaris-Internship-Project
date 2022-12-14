using BookLoversProject.Application.DTO;
using MediatR;

namespace BookLoversProject.Application.Queries.GetGenresQuery
{
    public class GetGenreQuery: IRequest<IEnumerable<GenreGetDTO>>
    {
    }
}
