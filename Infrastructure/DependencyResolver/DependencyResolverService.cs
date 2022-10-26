using Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public class DependencyResolverService
{
    public static void RegisterInfrastructureLayer(IServiceCollection services)
    {
        services.AddScoped<IBoxRepository, BoxRepository>(); 
    }
}