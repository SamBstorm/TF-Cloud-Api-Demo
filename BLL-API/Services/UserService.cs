using BLL_API.Entities;
using BLL_API.Mapper;
using Common_API.Repositories;
using DAL = DAL_API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL_API.Services
{
    public class UserService : IUserRepository<User>
    {
        private IUserRepository<DAL.User> _service;

        public UserService(IUserRepository<DAL.User> service)
        {
            _service = service;
        }

        public Guid Insert(User user)
        {
            return _service.Insert(user.ToDAL());
        }

        public Guid? Login(User user)
        {
            return _service.Login(user.ToDAL());
        }

        public void Disabled(Guid userId)
        {
            _service.Disabled(userId);
        }

        public void ChangePassword(User user)
        {
            _service.ChangePassword(user.ToDAL());
        }

        public User Get(Guid userId) 
        {
            return _service.Get(userId).ToBLL();
        }

        public IEnumerable<User> Get()
        {
            return _service.Get().Select(e => e.ToBLL());
        }
    }
}
