using Common_API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEB_API.Mapper;
using WEB_API.Models;
using BLL = BLL_API.Entities;

namespace WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserRepository<BLL.User> _userService;
        public UserController(IUserRepository<BLL.User> userService)
        {
            _userService = userService;
        }

        [HttpGet("{id:guid}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                return Ok(_userService.Get(id).ToGetModel());
            }
            catch (Exception ex)
            {
                return BadRequest(new { ErrorMessage = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult Register(UserRegisterModel user)
        {
            try
            {
                Guid id = _userService.Insert(user.ToBLL());
                return CreatedAtAction(nameof(Get),new { id = id}, user);
            }
            catch (Exception ex)
            {
                return BadRequest(new { ErrorMessage = ex.Message });
            }
        }
    }
}
