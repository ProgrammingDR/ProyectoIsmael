
using API.Entities;
using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace agendaBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Auth : Controller
    {
        private readonly UserService _authService;

        public static User user = new User();
        public Auth( UserService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register([FromBody] User request)
        {
            try
            {
                user.Id = request.Id;
                user.Name = request.Name;
                user.Email = request.Email;
                user.Password = request.Password;

                await _authService.SignUp(user);

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Login")]
        public async Task<ActionResult<bool>> Login( string UserName, string Password)
        {
            try
            {
                var isLogged = await _authService.SignIn(UserName, Password);
                return Ok(isLogged);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}