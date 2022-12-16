using BookLoversProject.Application.DTO;
using MediatR;

namespace BookLoversProject.Application.Queries.GetReviewQuery
{
    public class GetReviewsQuery: IRequest<IEnumerable<ReviewGetDTO>>
    {
    }
}
