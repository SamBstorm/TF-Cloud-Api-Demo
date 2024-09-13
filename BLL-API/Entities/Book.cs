using Common_API.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL_API.Entities
{
    public class Book : IBook
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? ISBN { get; set; }
        public int NbPages { get; set; }

    }
}
