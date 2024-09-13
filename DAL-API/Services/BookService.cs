using Common_API.Entities;
using Common_API.Repositories;
using DAL_API.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL_API.Services
{
    public class BookService : BaseService, IBookRepository<Book>
    {
        public BookService(IConfiguration config) : base(config, "Cloud-API")
        {
        }

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
