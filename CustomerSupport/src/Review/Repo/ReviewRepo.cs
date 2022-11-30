using Microsoft.EntityFrameworkCore;
using Review.Data;

namespace Review.Repo
{
    public class ReviewRepo : IReviewRepo
    {
        private readonly ReviewDataContext _db;

        public ReviewRepo(ReviewDataContext db)
        {
            _db = db;
        }

        public async Task<bool> CreateReview(Reviews review)
        {
            await _db.AddAsync(review);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<Reviews?> GetReviewByReviewId(int reviewId)
        {
                return await _db.Reviews.FirstOrDefaultAsync(review => review.Id == reviewId);
        }

        public Task<List<Reviews>> GetReviewsByCustomerId(int customerId)
        {
            return _db.Reviews.Where(review => review.CustomerId == customerId).ToListAsync();
        }

    }
}
