using App.Common.Classes.Base.Services;
using App.Common.Classes.DTO.Contracts.Task;
using App.Domain.Entities;

namespace App.Domain.Services.Task
{
    public interface ITaskService:IBaseService<TaskModel>
    {
        Task<List<VmGetTasksByUserId>> GetByUserIdAsync(Guid userId);
	}
}