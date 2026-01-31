using App.Common.Classes.Base.Controller;
using App.Common.Classes.Base.Services;
using App.Common.Classes.DTO.Contracts.Role;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RoleController : BaseController<RoleModel>
    {
        public RoleController(IBaseService<RoleModel> service) : base(service)
        {
        }
    }
}