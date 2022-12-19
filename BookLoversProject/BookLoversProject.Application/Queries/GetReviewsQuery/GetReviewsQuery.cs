using BookLoversProject.Application.DTO.ReviewDTOs;
using MediatR;

namespace BookLoversProject.Application.Queries.GetReviewQuery
{
    public class GetReviewsQuery: IRequest<IEnumerable<ReviewGetDTO>>
    {
    }
}
