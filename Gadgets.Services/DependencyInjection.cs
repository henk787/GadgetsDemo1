using Gadgets.Persistence; 
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Gadgets.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddPersistence(configuration);
        services.AddScoped<ServiceInitializer>();

        services.AddMediator(options =>
        {
            options.Assemblies = [typeof(DependencyInjection)];
            options.ServiceLifetime = ServiceLifetime.Scoped;
        });

        return services;
    }

}
