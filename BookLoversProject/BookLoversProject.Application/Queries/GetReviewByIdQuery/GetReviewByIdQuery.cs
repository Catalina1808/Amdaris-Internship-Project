using BookLoversProject.Application.DTO;
using MediatR;

namespace BookLoversProject.Application.Queries.GetReviewByIdQuery
{
    public class GetReviewByIdQuery: IRequest<ReviewGetDTO>
    {
        public int Id { get; set; }
    }
}
