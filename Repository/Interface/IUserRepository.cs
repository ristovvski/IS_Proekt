﻿using IS_Proekt.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IUserRepository
    {
        IEnumerable<BookStoreApplicationUser> GetAll();
        BookStoreApplicationUser Get(string? id);
        void Insert(BookStoreApplicationUser entity);
        void Update(BookStoreApplicationUser entity);
        void Delete(BookStoreApplicationUser entity);
    }

}
