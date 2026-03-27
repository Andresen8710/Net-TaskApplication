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

		public async Task<List<TaskEntity>> GetByUserIdAsync(Guid userId)
		{
			return await _context.Set<TaskEntity>().Where(t => t.UserId == userId).ToListAsync();
		}
	}
}