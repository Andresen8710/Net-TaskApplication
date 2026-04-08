using App.Common.Classes.Base.Controller;
using App.Common.Classes.Base.Services;
using App.Common.Classes.DTO.Contracts.Task;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TaskStatusController : BaseController<TaskStatusModel>
	{
		public TaskStatusController(IBaseService<TaskStatusModel> service) : base(service)
		{
		}
	}
}
