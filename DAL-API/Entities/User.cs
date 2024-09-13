using Common_API.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL_API.Entities
{
    public class User : IUser
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DisabledAt { get; set; }
    }
}
