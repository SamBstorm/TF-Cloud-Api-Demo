using System;
using System.Collections.Generic;
using System.Text;
using BLL = BLL_API.Entities;
using DAL = DAL_API.Entities;

namespace BLL_API.Mapper
{
    internal static class Mapper
    {
        #region User

        public static BLL.User ToBLL(this DAL.User entity)
        {
            if(entity is null) throw new ArgumentNullException(nameof(entity));
            return new BLL.User(entity);
        }

        public static DAL.User ToDAL(this BLL.User entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            return new DAL.User() { 
                UserId = entity.UserId,
                Email = entity.Email,
                Password = entity.Password,
                CreatedAt = entity.CreatedAt,
                DisabledAt = entity.DisabledAt
            };
        }

        #endregion
    }
}
