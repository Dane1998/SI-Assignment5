using Review.Data;
using Review.Repo;
using Shared.Shared;

namespace Review.Services
{
    public interface IReviewService
    {
        Task<bool> SaveReview(ReviewDTO reviewDto);
    }

    public class ReviewService : IReviewService
    {
        private readonly IReviewRepo? _reviewRepo;

        public async Task<bool> SaveReview(ReviewDTO reviewDto)
        {
            return await _reviewRepo.CreateReview(new Reviews
            {
                ReviewText = reviewDto.ReviewText,
                Rating = reviewDto.Rating
            });
        }
    }
   
}
