using SolarEnergy.Infra.DataBase;
using SolarEnergy.Domain.Models;
using SolarEnergy.Domain.Interfaces.Repositories;

namespace SolarEnergy.Infra.DataBase.Repositories;

public class UnidadeRepository : BaseRepository<Unidade, int>, IUnidadeRepository
{
    public UnidadeRepository(SolarDbContext context) : base(context)
    {
    }
}
