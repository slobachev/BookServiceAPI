using System.Collections.Generic;

namespace BookServiceAPI
{
    public interface IBookService
    {
        List<Book> GetBooks();
        Book GetBook(int id);
        void AddBook(Book item);
        void UpdateBook(Book item);
        void DeleteBook(int id);
        bool BookExsists(int id);
    }
}