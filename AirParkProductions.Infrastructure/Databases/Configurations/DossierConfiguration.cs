using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AirParkProductions.Domain.Models;

namespace AirParkProductions.Infrastructure.Databases.Configurations
{
    internal class DossierConfiguration : IEntityTypeConfiguration<Dossier>
    {
        public void Configure(EntityTypeBuilder<Dossier> builder)
        {
            builder.HasOne(c => c.Utilisateur).WithMany(e => e.Dossiers).HasForeignKey(c => c.UtilisateurId);
            builder.HasOne(c => c.Entreprise).WithMany(e => e.Dossiers).HasForeignKey(c => c.EntrepriseId);
        }
    }
}
