using Common_API.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common_API.Repositories
{
    public interface IUserRepository<TUser> where TUser : IUser
    {
        public TUser Get(Guid userId);
        public IEnumerable<TUser> Get();
        public Guid Insert(TUser user);
        public Guid? Login(TUser user);
        public void ChangePassword(TUser user);
        public void Disabled(Guid userId);
    }
}
