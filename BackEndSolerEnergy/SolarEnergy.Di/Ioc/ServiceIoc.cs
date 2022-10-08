using Microsoft.Extensions.DependencyInjection;
using SolarEnergy.Domain.Interfaces.Services;
using SolarEnergy.Domain.Services;

namespace SolarEnergy.Di.Ioc;

public static class ServiceIoc
{
    public static IServiceCollection RegisterServices(this IServiceCollection builder)
    {
        return builder
            .AddScoped<IGeracaoService, GeracaoService>()
            .AddScoped<IUserService, UserService>()
            .AddScoped<IUnidadeService, UnidadeService>();
    }
}
