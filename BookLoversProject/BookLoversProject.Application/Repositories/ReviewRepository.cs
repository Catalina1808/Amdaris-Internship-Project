using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Application.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private List<User> reviews;

        public ReviewRepository(List<User> reviews)
        {
            this.reviews = reviews;
        }

        public User AddReview(User review)
        {
            reviews.Add(review);
            return review;
        }

        public void DeleteReview(User review)
        {
            if (!reviews.Remove(review))
            {
                throw new Exceptions.ReviewNotFoundException("Exception occured, review not found!");
            }
        }

        public List<User> GetAllReviews()
        {
            return reviews;
        }

        public User GetReviewById(int id)
        {
            var review = reviews.FirstOrDefault(x => x.Id == id);
            if (review == null)
            {
                throw new Exceptions.ReviewNotFoundException("Exception occured, review not found!");
            }
            return review;
        }
    }
}
