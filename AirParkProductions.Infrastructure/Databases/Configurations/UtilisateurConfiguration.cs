using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AirParkProductions.Domain.Models;

namespace AirParkProductions.Infrastructure.Databases.Configurations
{
    internal class UtilisateurConfiguration : IEntityTypeConfiguration<Utilisateur>
    {
        public void Configure(EntityTypeBuilder<Utilisateur> builder)
        {
            builder.HasOne(c => c.Role).WithMany(e => e.Utilisateurs).HasForeignKey(c => c.RoleId);
            builder.HasOne(c => c.Entreprise).WithMany(e => e.Utilisateurs).HasForeignKey(c => c.EntrepriseId);
        }
    }
}
