using App.Common.Classes.Base.Controller;
using App.Common.Classes.Base.Extensions;
using App.Common.Classes.Base.Services;
using App.Common.Classes.Constants.Common;
using App.Common.Classes.DTO.Contracts.Task;
using App.Domain.Services.Task;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TaskController : BaseController<TaskModel>
	{
		private readonly ITaskService _taskService;

		public TaskController(IBaseService<TaskModel> service, ITaskService taskService) : base(service)
		{
			_taskService = taskService;
		}

		[HttpGet]
		[Route("getByUserId")]
		public async Task<IActionResult> GetByUserIdAsync(Guid userId)
		{
			try
			{
				if (userId == Guid.Empty) return BadRequest();
				var result = await _taskService.GetByUserIdAsync(userId);
				return Ok(result.AsResponseDTO(200, GlobalConstants.SUCCESS_PROCESS, null, true));
			}
			catch (Exception ex)
			{
				return StatusCode(500, ex.Message);
			}
		}
	}
}