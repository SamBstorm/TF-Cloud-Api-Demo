using BLL_API.Entities;
using Common_API.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL_API.Services
{
    public class BookService : IBookRepository<Book>
    {
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Book Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> Get()
        {
            throw new NotImplementedException();
        }

        public Book GetByISBN(string ISBN)
        {
            throw new NotImplementedException();
        }

        public int Insert(Book book)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Book book)
        {
            throw new NotImplementedException();
        }
    }
}
