using BookLoversProject.Application.DTO.ReviewDTOs;
using MediatR;

namespace BookLoversProject.Application.Queries.GetReviewsQuery
{
    public class GetReviewsQuery : IRequest<IEnumerable<ReviewGetDTO>>
    {
    }
}
