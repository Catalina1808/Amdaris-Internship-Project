using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;
using MediatR;

namespace BookLoversProject.Application.Commands.CreateReviewCommand
{
    public class CreateReviewCommandHander : IRequestHandler<CreateReviewCommand, int>
    {
        private readonly IReviewRepository _reviewRepository;

        public CreateReviewCommandHander(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public Task<int> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
        {
            var review = new Review
            {
                Comment = request.Comment,
                Date = request.Date
            };
            _reviewRepository.AddReview(review);
            return Task.FromResult(review.Id);
        }
    }
}
