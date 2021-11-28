using Microsoft.AspNetCore.Mvc;
using RedisDemo.Models;
using RedisDemo.Services;
using System.Threading.Tasks;

namespace RedisDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService) => _userService = userService;

        [HttpGet]
        public async Task<IActionResult> Get(string userId) => Ok(await _userService.Get(userId));

        [HttpPost]
        public async Task<IActionResult> Post(UserDTO model) => Ok(await _userService.SaveOrUpdate(model));

        [HttpDelete]
        public async Task<IActionResult> Delete(string userId)
        {
            await _userService.Delete(userId);
            return NoContent();
        }
    }
}
