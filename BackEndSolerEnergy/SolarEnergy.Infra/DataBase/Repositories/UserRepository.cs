using SolarEnergy.Infra.DataBase;
using SolarEnergy.Domain.Interfaces.Repositories;
using SolarEnergy.Domain.Models;
using SolarEnergy.Domain.DTOs;

namespace SolarEnergy.Infra.DataBase.Repositories;

public class UserRepository : BaseRepository<User, int>, IUserRepository
{
    public UserRepository(SolarDbContext context) : base (context)
    {
        
    }

    public User VerifyLogin(Login login)
    {
        return _context.Users.Where(u => u.Email == login.Email && u.Password == login.Password).FirstOrDefault();
    }
}
