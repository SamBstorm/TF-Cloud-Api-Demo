using Common_API.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common_API.Repositories
{
    public interface IBookRepository<TBook> : ICRUDRepository<TBook, int> where TBook : IBook
    {
        public TBook GetByISBN(string ISBN);
    }
}
