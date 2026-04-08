using App.Common.Classes.Base.Repository;
using App.Common.Classes.Base.Services;
using App.Common.Classes.DTO.Contracts.Task;
using App.Domain.Contracts.Repositories;
using App.Domain.Entities;
using AutoMapper;
using Microsoft.Extensions.Configuration;

namespace App.Domain.Services.Task
{
    public class TaskService : BaseService<TaskModel, TaskEntity>, ITaskService
    {
		private readonly ITaskRepository _taskRepository;
		public TaskService(IBaseRepository<TaskEntity> repository, IConfiguration configuration, IMapper mapper, ITaskRepository taskRepository) : base(repository, configuration, mapper)
        {
			_taskRepository = taskRepository;
		}

		public async Task<List<VmGetTasksByUserId>> GetByUserIdAsync(Guid userId)
		{
			return await _taskRepository.GetByUserIdAsync(userId);
		}
	}
}