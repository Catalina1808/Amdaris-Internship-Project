using MediatR;

namespace BookLoversProject.Application.Queries.GetBooksCountByGenre
{
    public class GetBooksCountByGenreQuery : IRequest<int>
    {
        public int GenreId { get; set; }
    }
}
