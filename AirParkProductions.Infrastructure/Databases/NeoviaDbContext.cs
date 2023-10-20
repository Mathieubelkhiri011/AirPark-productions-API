using Microsoft.EntityFrameworkCore;
using AirParkProductions.Domain.Models;
using System.Reflection;

namespace AirParkProductions.Infrastructure.Databases
{
    public class AirParkProductionsDbContext : DbContext
    {
        public AirParkProductionsDbContext(DbContextOptions<AirParkProductionsDbContext> options) : base(options)
        { }

        #region Tables
        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Entreprise> Entreprises { get; set; }
        public DbSet<Dossier> Dossiers { get; set; }
        #endregion

        /**
         * Si besoin d'utiliser des DTO pour des query :
         * 
         * Les créer dans le dossier Query de AirParkProductions.Domain
         * IMPORTANT : Mettre l'annotation [NotMapped] à votre DTO
         * L'utiliser comme ca : _dbContext.Set<CustomQueryExample>().Where(...).ToListAsync(_cancellationToken);
         * 
         * Ca évite de les définir ici en tant que DbSet
         * 
         * Ils seront injecter dans le DbContext via la méthode AddQueryDTOToDbContext
         */

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.AddQueryDTOToDbContext();
        }
    }

    public static class ModelBuilderExtensions
    {
        public static void AddQueryDTOToDbContext(this ModelBuilder modelBuilder)
        {
            Assembly dtoAssembly = Assembly.Load("AirParkProductions.Domain");

            List<Type> types = dtoAssembly.GetTypes().Where(t => "AirParkProductions.Domain.Query" == t.Namespace).ToList();

            types.ForEach(type =>
            {
                modelBuilder.Entity(type).HasNoKey();
            });
        }
    }
}

