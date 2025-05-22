using AutoMapper;
using OnlineEdu.DTO.DTOs.RoleDTOs;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Mapping
{
    public class RoleMapping:Profile
    {
        public RoleMapping()
        {
            CreateMap<AppRole, CreateRoleDto>().ReverseMap();
        }
    }
}
