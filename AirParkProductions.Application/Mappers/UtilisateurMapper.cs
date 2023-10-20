using AutoMapper;
using AirParkProductions.Domain.DTO;
using AirParkProductions.Domain.Models;

namespace AirParkProductions.Application.Mappers
{
    public class UtilisateurMapper : Profile
    {
        public UtilisateurMapper()
        {
            CreateMap<Utilisateur, UtilisateurDTO>();
            CreateMap<List<Utilisateur>, List<UtilisateurDTO>>();
            CreateMap<UtilisateurDTO, Utilisateur>();
        }
    }
}
