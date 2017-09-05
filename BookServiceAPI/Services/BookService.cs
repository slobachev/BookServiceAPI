using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookServiceAPI.Services
{
    public class BookService : IBookService
    {
        private readonly List<Book> books;

        public BookService()
        {
            books = new List<Book>
            {
                new Book { Id = 1, Title = "Les Misérables", ReleaseYear = 1862, Summary = "Les Misérables is a French historical novel by Victor Hugo, first published in 1862, that is considered one of the greatest novels of the 19th century." },
                new Book { Id = 2, Title = "Ulysses", ReleaseYear = 1922, Summary = "Ulysses is a modernist novel by Irish writer James Joyce." },
                new Book { Id = 3, Title = "Julius Caesar", ReleaseYear = 1599, Summary = "The Tragedy of Julius Caesar is a tragedy by William Shakespeare, believed to have been written in 1599." }
            };
        }
        public List<Book> GetBooks()
        {
            return books;
        }

        public Book GetBook(int id)
        {
            return books.FirstOrDefault(item => item.Id == id);
        }

        public void AddBook(Book item)
        {
            books.Add(item);
        }

        public void UpdateBook(Book item)
        {
            var target = books.FirstOrDefault(t => t.Id == item.Id);

            target.Title = item.Title;
            target.ReleaseYear = item.ReleaseYear;
            target.Summary = item.Summary;
        }

        public void DeleteBook(int id)
        {
            throw new NotImplementedException();
        }

        public bool BookExsists(int id)
        {
            throw new NotImplementedException();
        }
    }
}
