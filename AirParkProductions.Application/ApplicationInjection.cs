using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AirParkProductions.Application
{

    public static class ApplicationInjection
    {
        public static void AddServices(this IServiceCollection services)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            assembly.GetTypes().Where(t => $"{assembly.GetName().Name}.Services" == t.Namespace
                                        && !t.IsAbstract
                                        && !t.IsInterface
                                        && t.Name.EndsWith("Service"))
            .Select(a => new { assignedType = a })
            .ToList()
            .ForEach(typesToRegister =>
            {
                services.AddScoped(typesToRegister.assignedType);
            });
        }

        public static void AddMappers(this IServiceCollection services)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            services.AddAutoMapper(assembly);
        }
    }
}
