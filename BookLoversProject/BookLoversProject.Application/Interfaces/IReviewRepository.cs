using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Application.Interfaces
{
    public interface IReviewRepository
    {
        User AddReview(User review);

        User GetReviewById(int id);

        List<User> GetAllReviews();

        void DeleteReview(User review);
    }
}
