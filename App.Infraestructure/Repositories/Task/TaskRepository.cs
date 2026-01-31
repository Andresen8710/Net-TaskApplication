using App.Common.Classes.Base.Repository;
using App.Domain.Entities;
using App.Infraestructure.DataBase.Context;

namespace App.Infraestructure.Repositories.Task
{
    public class TaskRepository : BaseRepository<TaskEntity>
    {
        public TaskRepository(ApplicationContext context) : base(context)
        {
        }
    }
}