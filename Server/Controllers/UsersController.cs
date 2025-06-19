using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Server.Dtos;
using Server.Interfaces;
using Server.Services;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController(IUserService userService, ICurrentUserService currentUser) : ControllerBase
    {
        private readonly IUserService _userService = userService;
        private readonly ICurrentUserService _currentUser = currentUser;

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            if (_currentUser.UserId != id)
            {
                return Forbid();
            }
            var user = await _userService.GetUserById(id);
            if (user == null)
                return NotFound();

            return Ok(new UserDto(user));
        }
        [HttpGet("me")]
        public async Task<IActionResult> GetCurrentUser()
        {
            var id = _currentUser.UserId;
            if (id <= 0)
            {
                return NotFound();
            }
            var user = await _userService.GetUserById(id);
            if (user == null)
                return NotFound();

            return Ok(new UserDto(user));
        }
    }
}
