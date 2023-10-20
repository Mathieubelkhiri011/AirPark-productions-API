using AirParkProductions.Application.Base;
using AirParkProductions.Domain.Models;
using AirParkProductions.Infrastructure.Repository;

namespace AirParkProductions.Application.Services
{
    public class EntrepriseService : BaseService<EntrepriseRepository, Entreprise>
    {
        public EntrepriseService(EntrepriseRepository repository) : base(repository)
        {
        }
    }
}
