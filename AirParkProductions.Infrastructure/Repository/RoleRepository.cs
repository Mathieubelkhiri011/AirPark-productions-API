using Microsoft.AspNetCore.Http;
using AirParkProductions.Domain.Models;
using AirParkProductions.Infrastructure.Base;
using AirParkProductions.Infrastructure.Databases;

namespace AirParkProductions.Infrastructure.Repository
{
    public class RoleRepository : BaseRepository<Role, AirParkProductionsDbContext>
    {
        public RoleRepository(AirParkProductionsDbContext context, IHttpContextAccessor httpContext) : base(context, httpContext)
        {
        }
    }
}
