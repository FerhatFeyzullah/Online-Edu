using AutoMapper;
using OnlineEdu.DTO.DTOs.AppUserDTOs;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Mapping
{
    public class AppUserMapping:Profile
    {
        public AppUserMapping()
        {
            CreateMap<AppUser,ResultAppUserDto>().ReverseMap();
        }
    }
}
