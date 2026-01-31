using App.Common.Classes.Base.Repository;
using App.Common.Classes.Base.Services;
using App.Common.Classes.DTO.Contracts.Task;
using App.Domain.Entities;
using AutoMapper;
using Microsoft.Extensions.Configuration;

namespace App.Domain.Services.Task
{
    public class TaskService : BaseService<TaskModel, TaskEntity>, ITaskService
    {
        public TaskService(IBaseRepository<TaskEntity> repository, IConfiguration configuration, IMapper mapper) : base(repository, configuration, mapper)
        {
        }
    }
}