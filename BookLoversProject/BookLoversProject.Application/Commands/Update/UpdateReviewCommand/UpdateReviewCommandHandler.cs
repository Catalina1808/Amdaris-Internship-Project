using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;
using MediatR;

namespace BookLoversProject.Application.Commands.Update.UpdateReviewCommand
{
    public class UpdateReviewCommandHandler : IRequestHandler<UpdateReviewCommand, Review>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateReviewCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Review> Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
        {
            var toUpdate = new Review
            {
                Id = request.Id,
                Comment = request.Comment,
                Date = DateTime.Now
            };

            _unitOfWork.ReviewRepository.UpdateReview(toUpdate);

            await _unitOfWork.Save();

            return toUpdate;
        }
    }
}
