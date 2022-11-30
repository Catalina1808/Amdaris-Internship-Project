using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Infrastructure.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private List<Review> reviews;

        public ReviewRepository(List<Review> reviews)
        {
            this.reviews = reviews;
        }

        public Review AddReview(Review review)
        {
            reviews.Add(review);
            review.Id = reviews.Count;
            return review;
        }

        public void DeleteReview(Review review)
        {
            if (!reviews.Remove(review))
            {
                throw new Application.Exceptions.ReviewNotFoundException("Exception occured, review not found!");
            }
        }

        public List<Review> GetAllReviews()
        {
            return reviews;
        }

        public Review GetReviewById(int id)
        {
            var review = reviews.FirstOrDefault(x => x.Id == id);
            if (review == null)
            {
                throw new Application.Exceptions.ReviewNotFoundException("Exception occured, review not found!");
            }
            return review;
        }
    }
}
