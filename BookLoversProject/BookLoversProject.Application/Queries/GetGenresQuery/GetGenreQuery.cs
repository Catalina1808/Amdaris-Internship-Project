using MediatR;

namespace BookLoversProject.Application.Queries.GetGenresQuery
{
    public class GetGenreQuery: IRequest<IEnumerable<GenreDTO>>
    {
    }
}
