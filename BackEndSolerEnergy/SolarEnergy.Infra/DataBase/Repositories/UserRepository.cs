using SolarEnergy.Infra.DataBase;
using SolarEnergy.Domain.Interfaces.Repositories;
using SolarEnergy.Domain.Models;

namespace SolarEnergy.Infra.DataBase.Repositories;

public class UserRepository : BaseRepository<User, int>, IUserRepository
{
    public UserRepository(SolarDbContext context) : base (context)
    {
        
    }
}
