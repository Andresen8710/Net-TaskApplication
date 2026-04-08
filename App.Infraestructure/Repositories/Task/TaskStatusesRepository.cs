using App.Common.Classes.Base.Repository;
using App.Domain.Contracts.Repositories;
using App.Domain.Entities;
using App.Infraestructure.DataBase.Context;
using Microsoft.EntityFrameworkCore;

namespace App.Infraestructure.Repositories.Task
{
	public class TaskStatusesRepository : BaseRepository<TaskStatusEntity>, ITaskStatusRepository
	{
		public TaskStatusesRepository(ApplicationContext context) : base(context)
		{
		}
	}
}