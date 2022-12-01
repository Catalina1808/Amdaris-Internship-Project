using MediatR;

namespace BookLoversProject.Application.Queries.GetReviewsByBookId
{
    public class GetReviewsByBookIdQuery : IRequest<IEnumerable<ReviewDTO>>
    {
        public int BookId { get; set; }
    }
}
