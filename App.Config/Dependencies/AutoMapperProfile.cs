using App.Common.Classes.DTO.Contracts.Role;
using App.Common.Classes.DTO.Contracts.Task;
using App.Common.Classes.DTO.Contracts.User;
using App.Domain.Entities;
using AutoMapper;

namespace App.Config.Dependencies
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserEntity,UserModel>().ReverseMap();
            CreateMap<RoleEntity,RoleModel>().ReverseMap();
            CreateMap<TaskEntity,TaskModel>().ReverseMap();
            CreateMap<TaskEntryEntity,TaskEntryModel>().ReverseMap();
            CreateMap<UserEntity,UserRoleModel >()
                .ForMember(dest => dest.Role, opt =>opt.MapFrom(src=>src.Role.Name))
                .ReverseMap();
        }
    }
}