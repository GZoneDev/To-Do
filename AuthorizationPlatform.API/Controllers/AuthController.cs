using Microsoft.AspNetCore.Mvc;
using AuthenticationPlatform.Application.Services;
using AuthorizationPlatform.API.Contracts.Users;
using Microsoft.AspNetCore.Authorization;
using AuthenticationPlatform.Application.Common;

namespace AuthorizationPlatform.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IConfiguration _configuration;

        public AuthController(ILogger<AuthController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(
            [FromBody] RegisterUserRequest registerUserRequest,
            [FromServices] UserAuthorizationService userAuthorizationService)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await userAuthorizationService.RegisterAsync(
                                registerUserRequest.UserName,
                                registerUserRequest.Email,
                                registerUserRequest.Password);

            return result.IsSuccess ? Ok(new { message = result.Value }) : StatusCode((int)result.StatusCode, result.ErrorMessage);
        }

        
        [HttpPost("authorization")]
        public async Task<IActionResult> Login(
            [FromBody] LoginUserRequest loginUserRequest,
            [FromServices] UserAuthorizationService userAuthorizationService)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            //var result = await userAuthorizationService.LoginAsync(
            //    loginUserRequest.Email,
            //    loginUserRequest.Password);

            //if (result.IsSuccess)
            //{
            //    HttpContext.Response.Cookies.Append("token", result.Value);
            //    return Ok();
            //}          

            //return StatusCode((int)result.StatusCode, result.ErrorMessage);

            var result = await userAuthorizationService.LoginAsyncWithUser(
                loginUserRequest.Email,
                loginUserRequest.Password);

            if (result.IsSuccess)
            {
                HttpContext.Response.Cookies.Append("token", result.Value[0]);
                return Ok(new { message = result.Value[1] });
            }
            return StatusCode((int)result.StatusCode, result.ErrorMessage);
        }

        [Authorize]
        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Response.Cookies.Delete("token");
            return Ok(new { message = "Logout successful." });
        }

        [Authorize]
        [HttpGet("authentication")]
        public IActionResult Authentication()
        {
            return Ok();
        }
    }
}
