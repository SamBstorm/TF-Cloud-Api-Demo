using DAL_API.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DAL_API.Mapper
{
    internal static class Mapper
    {
        public static User ToUser(this IDataRecord reader) { 
            if(reader is null) throw new ArgumentNullException(nameof(reader));
            return new User(){
                UserId = (Guid)reader[nameof(User.UserId)],
                Email = (string)reader[nameof(User.Email)],
                Password = (string)reader[nameof(User.Password)],
                CreatedAt = (DateTime)reader[nameof(User.CreatedAt)],
                DisabledAt = (reader[nameof(User.DisabledAt)] is DBNull) ? null : (DateTime?)reader[nameof(User.DisabledAt)]
            };
        }
    }
}
