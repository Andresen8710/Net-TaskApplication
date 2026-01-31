using App.Common.Classes.Base.Repository;
using App.Infraestructure.DataBase.Context;
using App.Domain.Entities;
using App.Domain.Contracts.Repositories;

namespace App.Infraestructure.Repositories.Role
{
    public class RoleRepository : BaseRepository<RoleEntity>, IRoleRespository
    {
        public RoleRepository(ApplicationContext context) : base(context)
        {
        }
    }
}