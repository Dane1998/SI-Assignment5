using Review.Data;

namespace Review.Repo
{
    public interface IReviewRepo
    {
        public Task<Reviews> CreateReview(Reviews review);
        public Task<Reviews> GetReviewByReviewId(int reviewId);
        public Task<List<Reviews>> GetReviewsByUserId(int userId);
    }
}
