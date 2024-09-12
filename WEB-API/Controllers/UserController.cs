using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEB_API.Mapper;
using WEB_API.Models;

namespace WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private BLL_API.Services.UserService _userService;
        public UserController(BLL_API.Services.UserService userService)
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
