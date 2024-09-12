using BLL_API.Entities;
using BLL_API.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL_API.Services
{
    public class UserService
    {
        private DAL_API.Services.UserService _service;

        public UserService(DAL_API.Services.UserService service)
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
