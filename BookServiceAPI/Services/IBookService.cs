using System.Collections.Generic;

namespace BookServiceAPI
{
    internal interface IBookService
    {
        List<Book> GetBooks();
        Book GetBook();
        void AddBook(Book item);
        void UpdateBook(Book item);
        void DeleteBook(int id);
        void BookExsists(int id);
    }
}