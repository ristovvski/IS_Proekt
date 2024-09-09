using IS_Proekt.Domain;
using System;
using System.Collections.Generic;

namespace Service.Interface
{
    public interface IProductService
    {
        IEnumerable<Book> GetAllBooks();
        Book GetBookDetails(Guid productId);
        bool AddBook(Book product);
        bool UpdateBook(Book product);
        bool DeleteBook(Guid productId);
    }
}
