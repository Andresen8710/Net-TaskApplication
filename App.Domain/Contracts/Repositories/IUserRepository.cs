using App.Common.Classes.Base.Repository;
using App.Domain.Entities;

namespace App.Domain.Contracts.Repositories
{
    public interface IUserRepository:IBaseRepository<UserEntity>
    {
        Task<UserEntity> GetByUserNameAsync(string userName);
    }
}