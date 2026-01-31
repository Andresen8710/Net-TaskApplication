using App.Common.Classes.Base.Services;
using App.Common.Classes.DTO.Contracts.User;

namespace App.Domain.Services.User
{
    public interface IUserService : IBaseService<UserModel>
    {
        Task<UserModel> GetByUserNameAsync(string userName);
    }
}