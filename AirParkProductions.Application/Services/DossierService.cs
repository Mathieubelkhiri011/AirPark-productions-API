using AirParkProductions.Application.Base;
using AirParkProductions.Domain.Models;
using AirParkProductions.Infrastructure.Repository;

namespace AirParkProductions.Application.Services
{
    public class DossierService : BaseService<DossierRepository, Dossier>
    {
        public DossierService(DossierRepository repository) : base(repository)
        {
        }
    }
}
