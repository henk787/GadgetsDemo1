using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Gadgets.Persistence;

public static class DependencyInjection
{

    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<GadgetsDbContext>(options =>
        {
            options.UseInMemoryDatabase("GadgetsDb");
            //For debugging only:
            options.EnableDetailedErrors(true);
            //For debugging only:
            options.EnableSensitiveDataLogging(true);                
        });

        return services;
    }

}
