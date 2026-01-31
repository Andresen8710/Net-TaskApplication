using App.Common.Classes.Base.Services;
using App.Common.Classes.Constants.Common;
using App.Common.Classes.DTO.Contracts.User;
using App.Domain.Contracts.Repositories;
using App.Domain.Entities;
using AutoMapper;
using Microsoft.Extensions.Configuration;

namespace App.Domain.Services.User
{
    public class UserService : BaseService<UserModel, UserEntity>, IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository, IConfiguration configuration, IMapper mapper) : base(userRepository, configuration,mapper)
        {
            _userRepository = userRepository;
        }

        public async Task<UserModel> GetByUserNameAsync(string userName)
        {
            var user = _mapper.Map<UserModel>(await _userRepository.GetByUserNameAsync(userName));

            if (user == null) throw new ApplicationException(GlobalConstants.ERROR_USERNAME_NOT_FOUND);

            return user;
        }

    }
}