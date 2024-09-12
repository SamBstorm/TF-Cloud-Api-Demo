using WEB_API.Models;

namespace WEB_API.Mapper
{
    internal static class Mapper
    {
        #region User

        public static BLL_API.Entities.User ToBLL(this UserRegisterModel entity)
        {
            if(entity is null) throw new ArgumentNullException(nameof(entity));
            return new BLL_API.Entities.User(entity.Email, entity.Password);
        }

        public static UserGetModel ToGetModel(this BLL_API.Entities.User entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            return new UserGetModel() {
                Email = entity.Email,
                Password = entity.Password,
                CreatedAt = entity.CreatedAt,
                IsActive = entity.DisabledAt is null
            };
        }
        #endregion
    }
}
