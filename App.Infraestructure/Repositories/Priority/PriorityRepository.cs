using App.Common.Classes.Base.Repository;
using App.Domain.Entities;
using App.Infraestructure.DataBase.Context;

namespace App.Infraestructure.Repositories.Priority
{
    public class PriorityRepository : BaseRepository<PriorityEntity>
    {
        public PriorityRepository(ApplicationContext context) : base(context)
        {
        }
    }
}