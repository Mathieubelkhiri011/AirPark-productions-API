using AutoMapper;
using AirParkProductions.Domain.DTO;
using AirParkProductions.Domain.Models;

namespace AirParkProductions.Application.Mappers
{
    public class DossierMapper : Profile
    {
        public DossierMapper()
        {
            CreateMap<Dossier, DossierDTO>().ReverseMap();
            CreateMap<List<Dossier>, List<DossierDTO>>().ReverseMap();
        }
    }
}
