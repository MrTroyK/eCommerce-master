using System.Security.Cryptography;
using System.Threading.Tasks;
using eCommerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.Model;
using Repositories.Interfaces;

namespace eCommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {
        private SHA256CryptoServiceProvider SHA256;
        private readonly UserService _userService;

        public UserController(IUserService userService)
        {
            _userService = (UserService)userService;
        }

        [HttpPost("create")]
        public IActionResult New([FromBody] User user)
        {
            _userService.Create(user);
            return Ok(user);
            
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody]User userParam)
        {
            var user = await _userService.Authenticate(userParam.FirstName, userParam.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }

        [HttpDelete("delete")]
        public IActionResult Delete([FromBody] User user)
        {

            return Ok(_userService.Delete(user));

        }
    }
}