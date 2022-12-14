using SolarEnergy.Domain.Models;

namespace SolarEnergy.Domain.Interfaces.Repositories;

public interface IUnidadeRepository
{
    IList<Unidade> Get();
    Unidade GetById(int id);
    void Post(Unidade unidade);
    void Put(Unidade unidade);
    void Delete(Unidade unidade);
}
