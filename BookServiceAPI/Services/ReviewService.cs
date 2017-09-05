using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookServiceAPI.Models;

namespace BookServiceAPI.Services
{
    public class ReviewService : IReviewService
    {
        public List<Review> GetReviews(int bookId)
        {
            throw new NotImplementedException();
        }

        public Review GetReview(int bookId, int id)
        {
            throw new NotImplementedException();
        }

        public void AddReview(Review item)
        {
            throw new NotImplementedException();
        }

        public void UpdateReview(Review item)
        {
            throw new NotImplementedException();
        }

        public void DeleteReview(int id)
        {
            throw new NotImplementedException();
        }

        public bool ReviewExists(int bookId, int id)
        {
            throw new NotImplementedException();
        }
    }
}
