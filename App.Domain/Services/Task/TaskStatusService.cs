using App.Common.Classes.Base.Repository;
using App.Common.Classes.Base.Services;
using App.Common.Classes.DTO.Contracts.Task;
using App.Domain.Entities;
using AutoMapper;
using Microsoft.Extensions.Configuration;

namespace App.Domain.Services.Task
{
	public class TaskStatusService : BaseService<TaskStatusModel, TaskStatusEntity>
	{
		public TaskStatusService(IBaseRepository<TaskStatusEntity> repository, IConfiguration configuration, IMapper mapper) : base(repository, configuration, mapper)
		{
		}
	}
}