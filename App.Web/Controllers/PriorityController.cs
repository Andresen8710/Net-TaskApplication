using App.Common.Classes.Base.Controller;
using App.Common.Classes.Base.Services;
using App.Common.Classes.DTO.Contracts.Priority;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PriorityController : BaseController<PriorityModel>
	{
		public PriorityController(IBaseService<PriorityModel> service) : base(service)
		{
		}
	}
}
