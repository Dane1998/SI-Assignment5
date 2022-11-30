using Review.Data;

namespace Review.Repo
{
    public interface IReviewRepo
    {
        public Task<bool> CreateReview(Reviews review);
        public Task<Reviews?> GetReviewByReviewId(int reviewId);
        public Task<List<Reviews>> GetReviewsByCustomerId(int customerId);
    }
}
