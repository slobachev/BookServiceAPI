using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookServiceAPI.Models;

namespace BookServiceAPI.Services
{
    public class ReviewService : IReviewService
    {
        private readonly List<Review> reviews;
        
        public ReviewService() { }
        
        public List<Review> GetReviews(int bookId)
        {
            return reviews.Where(r => r.BookId == bookId).ToList();
        }

        public Review GetReview(int bookId, int id)
        {
            return reviews.FirstOrDefault(r => r.BookId == bookId && r.Id == id);
        }

        public void AddReview(Review item)
        {
            reviews.Add(item);
        }

        public void UpdateReview(Review item)
        {
            var target = reviews.FirstOrDefault(r => r.Id == item.Id);
            
            target.Commnet = item.Comment;
            target.Reviewer = item.Reviewer;
        }

        public void DeleteReview(int id)
        {
            var target = reviews.FirstOrDefault(r => r.Id == id);
            reviews.Remove(target);
        }

        public bool ReviewExists(int bookId, int id)
        {
            return this.reviews.Any(r => r.MovieId == movieId && r.Id == id);
        }
    }
}
