using App.Common.Classes.DTO.Contracts.Auth;

namespace App.Authorization.Services.Contracts
{
    public interface IAuthService
    {
        Task<AuthResponseModel> Login(AuthRequestModel request);
    }
}