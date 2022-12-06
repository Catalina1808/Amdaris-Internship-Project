using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;
using MediatR;

namespace BookLoversProject.Application.Commands.CreateReviewCommand
{
    public class CreateReviewCommandHander : IRequestHandler<CreateReviewCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateReviewCommandHander (IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
        {
            var review = new Review
            {
                Comment = request.Comment,
                Date = request.Date
            };

            await _unitOfWork.ReviewRepository.AddReview(review);
            await _unitOfWork.Save();

            return review.Id;
        }
    }
}
