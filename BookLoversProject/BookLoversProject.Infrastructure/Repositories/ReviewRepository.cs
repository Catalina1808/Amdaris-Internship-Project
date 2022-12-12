using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;
using Microsoft.EntityFrameworkCore;

namespace BookLoversProject.Infrastructure.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly ApplicationContext _context;

        public ReviewRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Review> AddReviewAsync(Review review)
        {
            await _context.Reviews.AddAsync(review);
            return review;
        }

        public async Task DeleteReviewAsync(int id)
        {
            var review = await _context.Reviews.SingleOrDefaultAsync(r => r.Id == id);
            if (review == null)
            {
                throw new Application.Exceptions.ReviewNotFoundException("Exception occured, review not found!");
            }
            _context.Reviews.Remove(review);
        }

        public async Task<ICollection<Review>> GetAllReviewsAsync()
        {
            return await _context.Reviews.ToListAsync();
        }

        public async Task<Review> GetReviewByIdAsync(int id)
        {
            var review = await _context.Reviews.SingleOrDefaultAsync(x => x.Id == id);
            if (review == null)
            {
                throw new Application.Exceptions.ReviewNotFoundException("Exception occured, review not found!");
            }
            return review;
        }
    }
}
