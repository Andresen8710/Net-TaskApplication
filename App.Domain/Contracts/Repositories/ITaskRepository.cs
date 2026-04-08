using App.Common.Classes.Base.Repository;
using App.Domain.Entities;

namespace App.Domain.Contracts.Repositories
{
    public interface ITaskRepository:IBaseRepository<TaskEntity>
    {
		Task<List<VmGetTasksByUserId>> GetByUserIdAsync(Guid userId);
	}
}