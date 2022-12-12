using BookLoversProject.Application.DTO;
using MediatR;

namespace BookLoversProject.Application.Queries.GetAuthorsQuery
{
    public class GetAuthorsQuery : IRequest<IEnumerable<AuthorDTO>>
    {
    }
}
