using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Application.Interfaces
{
    public interface IReviewRepository
    {
        Task<Review> AddReview(Review review);

        Task<Review> GetReviewById(int id);

        Task<ICollection<Review>> GetAllReviews();

        Task DeleteReview(int id);
    }
}
