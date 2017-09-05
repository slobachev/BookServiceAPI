using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookServiceAPI.Models;

namespace BookServiceAPI.Services
{
    public interface IReviewService
    {
        List<Review> GetReviews(int bookId);
        Review GetReview(int bookId, int id);
        void AddReview(Review item);
        void UpdateReview(Review item);
        void DeleteReview(int id);
        bool ReviewExists(int bookId, int id);
    }
}
