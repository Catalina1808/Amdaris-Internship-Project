using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Infrastructure.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly ApplicationContext _context;

        public ReviewRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Review AddReview(Review review)
        {
            _context.Reviews.Add(review);
            return review;
        }

        public void DeleteReview(int id)
        {
            var review = _context.Reviews.FirstOrDefault(r => r.Id == id);
            if (review == null)
            {
                throw new Application.Exceptions.ReviewNotFoundException("Exception occured, review not found!");
            }
            _context.Reviews.Remove(review);
        }

        public ICollection<Review> GetAllReviews()
        {
            return _context.Reviews.ToList();
        }

        public Review GetReviewById(int id)
        {
            var review = _context.Reviews.FirstOrDefault(x => x.Id == id);
            if (review == null)
            {
                throw new Application.Exceptions.ReviewNotFoundException("Exception occured, review not found!");
            }
            return review;
        }
    }
}
