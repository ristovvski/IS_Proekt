using IS_Proekt.Domain;
using System;
using System.Collections.Generic;

namespace Service.Interface
{
    public interface IAuthorService
    {
        IEnumerable<Author> GetAllAuthors();
        Author GetAuthorDetails(Guid authorId);
        bool AddAuthor(Author author);
        bool UpdateAuthor(Author author);
        bool DeleteAuthor(Guid authorId);
    }
}
