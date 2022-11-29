﻿using Review.Data;

namespace Review.Repo
{

    public interface IReviewRepo
    {
        public Task<Reviews> CreateReview(Reviews review);
        public Task<Reviews> GetReviewByReviewId(int reviewId);
        public Task<List<Reviews>> GetReviewsByUserId(int userId);
    }

    public class ReviewRepo : IReviewRepo
    {
        private readonly ReviewDataContext _db;

        public ReviewRepo(ReviewDataContext db)
        {
            _db = db;
        }

        public async Task<Reviews> CreateReview(Reviews review)
        {
            await _db.AddAsync(review);
            await _db.SaveChangesAsync();
            return review;
        }

        public async Task<Reviews> GetReviewByReviewId(int reviewId)
        {
            return _db.Reviews.FirstOrDefault(review => review.ReviewId == reviewId);
        }

        public async Task<List<Reviews>> GetReviewsByUserId(int userId)
        {
            return _db.Reviews.Where(x => x.userId == userId).ToList();
        }
    }
}
