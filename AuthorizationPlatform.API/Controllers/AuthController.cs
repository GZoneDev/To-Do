using Microsoft.AspNetCore.Mvc;
using AuthenticationPlatform.Application.Services;
using AuthorizationPlatform.API.Contracts.Users;
using Microsoft.AspNetCore.Authorization;

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
            var result = await userAuthorizationService.RegisterAsync(
                                registerUserRequest.UserName,
                                registerUserRequest.Email,
                                registerUserRequest.Password);

            return result.IsSuccess ? Ok(result.Value) : StatusCode((int)result.StatusCode, result.ErrorMessage);
        }

        
        [HttpPost("authorization")]
        public async Task<IActionResult> Login(
            [FromBody] LoginUserRequest loginUserRequest,
            [FromServices] UserAuthorizationService userAuthorizationService)
        {
            var result = await userAuthorizationService.LoginAsync(
                loginUserRequest.Email,
                loginUserRequest.Password);

            if (result.IsSuccess)
            {
                HttpContext.Response.Cookies.Append("token", result.Value);
                return Ok();
            }          

            return StatusCode((int)result.StatusCode, result.ErrorMessage);
        }

        [Authorize]
        [HttpPost("authentication")]
        public async Task<IActionResult> Authentication()
        {
            return Ok();
        }
    }
}
