using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Gadgets.Persistence; 

namespace Gadgets.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddPersistence(configuration);
        services.AddScoped<ServiceInitializer>();
        
        return services;
    }

}
