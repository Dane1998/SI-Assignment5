using Review.Repo;
using Microsoft.AspNetCore.Mvc;
using Review.Data;

namespace Review.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewRepo _reviewRepo;

        public ReviewController(IReviewRepo reviewRepo)
        {
            _reviewRepo = reviewRepo;
        }

        [HttpPost]
        public async Task<IActionResult> CreateReview(Reviews review)
        {
            var result = await _reviewRepo.CreateReview(review);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetReviewByReviewId(int reviewId)
        {
            var result = await _reviewRepo.GetReviewByReviewId(reviewId);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetReviewsByCustomerId(int customerId)
        {
            var result = await _reviewRepo.GetReviewsByCustomerId(customerId);
            return Ok(result);
        }
    }
}
