using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AirParkProductions.Domain.Models;

namespace AirParkProductions.Infrastructure.Databases.Configurations
{
    internal class EntrepriseConfiguration : IEntityTypeConfiguration<Entreprise>
    {
        public void Configure(EntityTypeBuilder<Entreprise> builder)
        {
        }
    }
}
