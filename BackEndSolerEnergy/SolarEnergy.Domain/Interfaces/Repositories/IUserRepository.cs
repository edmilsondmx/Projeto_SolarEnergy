using SolarEnergy.Domain.Models;

namespace SolarEnergy.Domain.Interfaces.Repositories;

public interface IUserRepository
{
    IList<User> Get();
    User GetById(int id);
    void Post(User user);
    void Put(User user);
    void Delete(User user);
}
