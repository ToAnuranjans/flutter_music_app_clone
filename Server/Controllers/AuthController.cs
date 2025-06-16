using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Dtos;
using Server.Interfaces;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService auth) : ControllerBase
    {
        private readonly IAuthService _auth = auth;

        [HttpPost("signup")]
        public async Task<IActionResult> Signup(UserSignupDto dto)
        {

            var createdUser = await _auth.SignupAsync(dto);
            Console.WriteLine(createdUser);
            if (createdUser == null)
            {
                return BadRequest("Email already exists");
            }
            return CreatedAtAction(nameof(UsersController.GetUserById), "Users", new { id = createdUser.Id }, new UserDto(createdUser));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto dto)
        {
            var token = await _auth.LoginAsync(dto);
            return token != null ? Ok(new { token }) : Unauthorized("Invalid credentials");
        }


    }
}
