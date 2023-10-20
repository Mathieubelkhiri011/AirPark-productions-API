using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AirParkProductions.Infrastructure.Databases;
using System.Reflection;

namespace AirParkProductions.Infrastructure
{

    public static class InfrastructureInjection
    {
        public static void AddDatabaseContext(this IServiceCollection services, string config)
        {
            services.AddDbContext<AirParkProductionsDbContext>(options =>
            {
#if DEBUG
                options.EnableSensitiveDataLogging(true);
#endif
                options.UseMySql(config, ServerVersion.AutoDetect(config));
            }, ServiceLifetime.Transient);

            // services.BuildServiceProvider().GetService<AirParkProductionsDbContext>().Database.Migrate();
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            assembly.GetTypes().Where(t => $"{assembly.GetName().Name}.Repository" == t.Namespace
                                        && !t.IsAbstract
                                        && !t.IsInterface
                                        && t.Name.EndsWith("Repository"))
            .Select(a => new { assignedType = a })
            .ToList()
            .ForEach(typesToRegister =>
            {
                services.AddScoped(typesToRegister.assignedType);
            });
        }
    }
}
