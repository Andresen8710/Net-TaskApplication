using App.Common.Classes.Base.Controller;
using App.Common.Classes.Base.Services;
using App.Common.Classes.DTO.Contracts.Task;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskEntryController : BaseController<TaskEntryModel>
    {
        public TaskEntryController(IBaseService<TaskEntryModel> service) : base(service)
        {
        }
    }
}