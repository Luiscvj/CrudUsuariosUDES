using AutoMapper;
using CrudUdes.Api.DTOS.RoleDTOS;
using CrudUdes.Api.DTOS.UserDTOS;
using CrudUdes.Domain.Entities;

namespace CrudUdes.Api.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        {
            CreateMap<Role, RoleDto>().ReverseMap();
            CreateMap<Role, RoleInfoDto>().ReverseMap();    
            CreateMap<User, UserRolesDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();

        }    
    }
}
