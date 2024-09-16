using Common_API.Repositories;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
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
        private IConfiguration _config;
        public UserController(
            IUserRepository<BLL.User> userService,
            IConfiguration config)
        {
            _userService = userService;
            _config = config;
        }

        [HttpGet("{id:guid}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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

        [HttpPost("Auth")]
        [ProducesResponseType<SuccessLoginModel>(200)]
        [ProducesResponseType(400)]
        public IActionResult Login(UserRegisterModel login)
        {
            try
            {
                Guid? id = _userService.Login(login.ToBLL());
                if(id is null) return Unauthorized();
                UserGetModel user = _userService.Get((Guid)id).ToGetModel();
                return Ok(new SuccessLoginModel() { Token = CreateToken(user)});
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [NonAction]
        private string CreateToken(UserGetModel model)
        {
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["jwt:secretKey"]));

            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new JwtSecurityToken(
                _config["jwt:issuer"],
                _config["jwt:audience"],
                new List<Claim>() { new Claim("email", model.Email) },
                expires : DateTime.Now.AddMinutes(2),
                signingCredentials : credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
