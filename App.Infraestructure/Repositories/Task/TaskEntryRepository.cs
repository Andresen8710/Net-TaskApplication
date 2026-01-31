using App.Common.Classes.Base.Repository;
using App.Infraestructure.DataBase.Context;
using App.Domain.Entities;
using App.Domain.Contracts.Repositories;

namespace App.Infraestructure.Repositories.Task
{
    public class TaskEntryRepository : BaseRepository<TaskEntryEntity>, ITaskEntryRepository
    {
        public TaskEntryRepository(ApplicationContext context) : base(context)
        {
        }
    }
}