using App.Authorization.Services.Contracts;
using App.Common.Classes.Constants.Common;
using App.Common.Classes.DTO.Contracts.Auth;
using App.Common.Classes.DTO.Contracts.User;
using App.Domain.Contracts.Repositories;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace App.Authorization.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        //private readonly JwtSettings _jwtSettings;
        private readonly IMapper _mapper;

        public AuthService(IUserRepository userRepository, IConfiguration configuration, IMapper mapper)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _mapper = mapper;
        }

        public async Task<AuthResponseModel> Login(AuthRequestModel request)
        {
            var userEntity = await _userRepository.GetByUserNameAsync(request.UserName);

            if (userEntity == null) throw new ApplicationException(GlobalConstants.ERROR_USERNAME_NOT_FOUND);

            if (userEntity.Password != request.Password) throw new ApplicationException(GlobalConstants.ERROR_INVALID_PASSWORD);

            var user = _mapper.Map<UserRoleModel>(userEntity);

            var token = await GenerateToken(user);

            var authResponse = new AuthResponseModel
            {
                Id = user.Id,
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Email = user.Email,
                UserName = user.UserName,
                Name = user.UserName,
                LastName = user.LastName,
                CreationDate = user.CreationDate,
                RoleId = user.RoleId,
                Role = user.Role,
                IsAdmin = user.IsAdmin
            };

            return authResponse;
        }


        private async Task<JwtSecurityToken> GenerateToken(UserRoleModel user)
        {
            var SecurityKey = _configuration["Jwt:SecretKey"];
            var iss = _configuration["Jwt:Issuer"];
            var aud = _configuration["Jwt:Audience"];
            var Minu = _configuration["Jwt:DurationInMinutes"];

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecurityKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Surname, user.LastName),
                new Claim(ClaimTypes.NameIdentifier, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role,user.Role),
            };

            var jwtSecurityToken = new JwtSecurityToken(
                iss,
                aud,
                claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(Minu)),
                signingCredentials: credentials
                );

            return jwtSecurityToken;
        }
    }
}