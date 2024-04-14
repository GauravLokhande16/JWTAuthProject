using JWTAuthProject.Contracts;
using Microsoft.AspNetCore.Mvc;
using SharedClassLibrary.Dtos;

namespace JWTAuthProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController(IUserAccount userAccount) :ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserDTO userDTO) 
        { 
            var response = await userAccount.CreateAccount(userDTO);
            return Ok(response);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            var response = await userAccount.LoginAccount(loginDTO);
            return Ok(response);
        }
    }
}
