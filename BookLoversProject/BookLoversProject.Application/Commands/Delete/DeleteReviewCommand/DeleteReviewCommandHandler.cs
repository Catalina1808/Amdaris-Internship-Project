using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;
using MediatR;

namespace BookLoversProject.Application.Commands.Delete.DeleteReviewCommand
{
    public class DeleteReviewCommandHandler : IRequestHandler<DeleteReviewCommand, Review>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteReviewCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Review> Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
        {
            var review = await _unitOfWork.ReviewRepository.GetReviewByIdAsync(request.Id);

            _unitOfWork.ReviewRepository.DeleteReview(review);

            await _unitOfWork.Save();

            return review;
        }
    }
}
