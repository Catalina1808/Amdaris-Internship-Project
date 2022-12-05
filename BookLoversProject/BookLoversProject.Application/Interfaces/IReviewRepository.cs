using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Application.Interfaces
{
    public interface IReviewRepository
    {
        Review AddReview(Review review);

        Review GetReviewById(int id);

        ICollection<Review> GetAllReviews();

        void DeleteReview(int id);
    }
}
