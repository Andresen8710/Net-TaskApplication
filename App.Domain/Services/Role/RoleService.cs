using App.Common.Classes.Base.Repository;
using App.Common.Classes.Base.Services;
using App.Common.Classes.DTO.Contracts.Role;
using App.Domain.Entities;
using AutoMapper;
using Microsoft.Extensions.Configuration;

namespace App.Domain.Services.Role
{
    public class RoleService : BaseService<RoleModel, RoleEntity>, IRoleService
    {
        public RoleService(IBaseRepository<RoleEntity> repository, IConfiguration configuration, IMapper mapper) : base(repository, configuration, mapper)
        {
        }
    }
}