using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Application.Interfaces
{
    public interface IReviewRepository
    {
        Task<Review> AddReviewAsync(Review review);

        Task<Review> GetReviewByIdAsync(int id);

        Task<ICollection<Review>> GetAllReviewsAsync();

        void DeleteReview(Review review);

        void UpdateReview(Review review);
    }
}
