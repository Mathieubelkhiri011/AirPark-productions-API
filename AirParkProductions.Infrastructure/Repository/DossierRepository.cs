using Microsoft.AspNetCore.Http;
using AirParkProductions.Domain.Models;
using AirParkProductions.Infrastructure.Base;
using AirParkProductions.Infrastructure.Databases;

namespace AirParkProductions.Infrastructure.Repository
{
    public class DossierRepository : BaseRepository<Dossier, AirParkProductionsDbContext>
    {
        public DossierRepository(AirParkProductionsDbContext context, IHttpContextAccessor httpContext) : base(context, httpContext)
        {
        }
    }
}
