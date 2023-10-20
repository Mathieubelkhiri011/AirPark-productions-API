using AutoMapper;
using AirParkProductions.Domain.DTO;
using AirParkProductions.Domain.Models;

namespace AirParkProductions.Application.Mappers
{
    public class EntrepriseMapper : Profile
    {
        public EntrepriseMapper()
        {
            CreateMap<Entreprise, EntrepriseDTO>();
            CreateMap<List<Entreprise>, List<EntrepriseDTO>>();
            CreateMap<EntrepriseDTO, Entreprise>();
        }
    }
}
