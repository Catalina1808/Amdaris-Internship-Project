using BookLoversProject.Application.DTO.ReviewDTOs;
using MediatR;

namespace BookLoversProject.Application.Queries.GetReviewByIdQuery
{
    public class GetReviewByIdQuery: IRequest<ReviewGetDTO>
    {
        public int Id { get; set; }
    }
}
