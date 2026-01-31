using App.Common.Classes.Base.Controller;
using App.Common.Classes.DTO.Contracts.User;
using App.Domain.Services.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController<UserModel>
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService) :base(userService)
        { 
            _userService = userService;
        }

        [HttpGet, Route("getByUserName")]
        public async Task<IActionResult> GetByUserNameAsync([FromBody] string userName)
        {
            try
            {
                var users = await _userService.GetByUserNameAsync(userName);

                if (users == null) return NotFound();
                return Ok(users);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
