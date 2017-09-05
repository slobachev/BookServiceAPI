using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookServiceAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookServiceAPI.Controllers
{
    [Route("api/books")]
    public class BooksController : Controller
    {
        private IBookService BookService { get; }

        public BooksController(IBookService service)
        {
            BookService = service;
        }
        // GET api/books
        [HttpGet]
        public IActionResult Get()
        {
            var model = BookService.GetBooks();

            var outputModel = ToOutputModel(model);
            return Ok(outputModel);
        }

        // GET api/books/5
        [HttpGet("{id}", Name = "GetBook")]
        public IActionResult Get(int id)
        {
            var model = BookService.GetBook(id);
            if (model == null)
            {
                return NotFound();
            }

            var outputModel = ToOutputModel(model);
            return Ok(outputModel);
        }

        // POST api/books
        [HttpPost]
        public IActionResult Create([FromBody]Book book)
        {
            if (book == null)
            {
                return BadRequest();
            }

            BookService.AddBook(book);
            var outputModel = ToOutputModel(book);
            return CreatedAtRoute("GetBook", new {outputModel.Id}, outputModel);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]Book book)
        {
            if (book == null || id != book.Id)
            {
                return BadRequest();
            }

            if (BookService.BookExsists(id))
            {
                return NotFound();
            }

            BookService.UpdateBook(book);
            return NoContent();
        }

        // DELETE api/books/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!BookService.BookExsists(id))
            {
                return NotFound();
            }
            
            BookService.DeleteBook(id);
            return NoContent();
        }

        #region Mappings

        private BookOutput ToOutputModel(Book item) =>
            new BookOutput
            {
                Id = item.Id,
                Title = item.Title,
                ReleaseYear = item.ReleaseYear,
                Summary = item.Summary,
                LastReadAt = DateTime.Now
            };

        private List<BookOutput> ToOutputModel(IEnumerable<Book> model) =>
            model.Select(ToOutputModel).ToList();


        #endregion

    }
}
