using AutoMapper;
using AirParkProductions.Domain.DTO;
using AirParkProductions.Domain.Models;

namespace AirParkProductions.Application.Mappers
{
    public class RoleMapper : Profile
    {
        public RoleMapper()
        {
            CreateMap<Role, RoleDTO>();
            CreateMap<List<Role>, List<RoleDTO>>();
            CreateMap<RoleDTO, Role>();
        }
    }
}
