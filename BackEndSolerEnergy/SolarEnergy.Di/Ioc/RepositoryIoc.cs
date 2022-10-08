using Microsoft.Extensions.DependencyInjection;
using SolarEnergy.Infra.DataBase;
using SolarEnergy.Domain.Interfaces.Repositories;
using SolarEnergy.Infra.DataBase.Repositories;

namespace SolarEnergy.Di.Ioc;

public static class RepositoryIoc
{
    public static IServiceCollection RegisterRepositories(this IServiceCollection builder)
    {
        return builder
            .AddDbContext<SolarDbContext>()
            .AddScoped<IGeracaoRepository, GeracaoRepository>()
            .AddScoped<IUserRepository, UserRepository>()
            .AddScoped<IUnidadeRepository, UnidadeRepository>();
    }
}
