using SolarEnergy.Infra.DataBase;
using SolarEnergy.Domain.Models;
using SolarEnergy.Domain.Interfaces.Repositories;

namespace SolarEnergy.Infra.DataBase.Repositories;

public class GeracaoRepository : BaseRepository<Geracao, int> , IGeracaoRepository
{
    public GeracaoRepository(SolarDbContext context) : base (context)
    {
    }
}
