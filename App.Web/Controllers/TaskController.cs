using App.Common.Classes.Base.Controller;
using App.Common.Classes.Base.Services;
using App.Common.Classes.DTO.Contracts.Task;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : BaseController<TaskModel>
    {
        public TaskController(IBaseService<TaskModel> service) : base(service)
        {
        }
    }
}