using App.Authorization.Services.Contracts;
using App.Common.Classes.DTO.Contracts.Auth;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(AuthRequestModel request)
        {
            if (request == null) return BadRequest();

            var result = await _authService.Login(request);

            return Ok(result);
        }
    }
}