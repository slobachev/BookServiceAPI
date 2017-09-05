using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookServiceAPI.Models;
using BookServiceAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookServiceAPI.Controllers
{

    [Route("api/books/{bookId}/reviews")]
    public class ReviewController : Controller
    {
        private readonly IBookService bookService;
        private readonly IReviewService reviewService;

        public ReviewController(IBookService bookService, IReviewService reviewService)
        {
            this.bookService = bookService;
            this.reviewService = reviewService;
        }

        // GET: api/Review
        [HttpGet]
        public IActionResult Get(int bookId)
        {
            var model = reviewService.GetReviews(bookId);
            var outputModel = ToOutputModel(model);
            return Ok(outputModel);
        }

        // GET: api/Review/5
        [HttpGet("{id}", Name = "GetReview")]
        public IActionResult Get(int bookId, int reviewId)
        {
            var model = reviewService.GetReview(bookId, reviewId);
            if (model == null)
            {
                return NotFound();
            }

            var outputModel = ToOutputModel(model);
            return Ok(outputModel);
        }
        
        // POST: api/Review
        [HttpPost]
        public IActionResult Create(int bookId, [FromBody]Review review)
        {
            if (review == null)
                return BadRequest();

            if (!bookService.BookExsists(bookId))
                return NotFound();

            reviewService.AddReview(review);

            var outputModel = ToOutputModel(review);
            return CreatedAtRoute("GetReview",
                new { bookId = outputModel.BookId, id = outputModel.Id },
                outputModel);
        }
        
        // PUT: api/Review/5
        [HttpPut("{id}")]
        public IActionResult Update(int bookId, int reviewId, [FromBody]Review review)
        {
            if (review == null || reviewId != review.Id)
            {
                return BadRequest();
            }

            if (!reviewService.ReviewExists(bookId, reviewId))
            {
                return NotFound();
            }

            reviewService.UpdateReview(review);
            return NoContent();

        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int bookId, int reviewId)
        {
            if (!reviewService.ReviewExists(bookId, reviewId))
                return NotFound();

            reviewService.DeleteReview(reviewId);

            return NoContent();
        }

        #region Mappings

        private ReviewOutput ToOutputModel(Review model) => 
            new ReviewOutput
            {
                Id = model.Id,
                Reviewer = model.Reviewer,
                Comment = model.Comment,
                BookId = model.BookId,
                LastReadAt = DateTime.Now
            };

        private List<ReviewOutput> ToOutputModel(IEnumerable<Review> model) => 
            model.Select(ToOutputModel).ToList();

        #endregion
    }
}
