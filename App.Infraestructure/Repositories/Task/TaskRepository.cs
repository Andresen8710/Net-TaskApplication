using App.Common.Classes.Base.Repository;
using App.Domain.Contracts.Repositories;
using App.Domain.Entities;
using App.Infraestructure.DataBase.Context;
using Microsoft.EntityFrameworkCore;

namespace App.Infraestructure.Repositories.Task
{
    public class TaskRepository : BaseRepository<TaskEntity>, ITaskRepository
	{
        public TaskRepository(ApplicationContext context) : base(context)
        {
        }

		public async Task<List<VmGetTasksByUserId>> GetByUserIdAsync(Guid userId)
		{
			//return await _context.Set<TaskEntity>()
			//	.Include(ts=>ts.TaskStatus)
			//	.Where(t => t.UserId == userId).ToListAsync();

			return await _context.Set<VmGetTasksByUserId>()
				.Where(x => x.UserId == userId)
				.ToListAsync();
		}
	}
}