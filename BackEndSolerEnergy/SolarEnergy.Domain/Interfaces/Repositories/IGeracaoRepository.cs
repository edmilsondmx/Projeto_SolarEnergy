using SolarEnergy.Domain.Models;

namespace SolarEnergy.Domain.Interfaces.Repositories;

public interface IGeracaoRepository
{
    IList<Geracao> Get();
    Geracao GetById(int id);
    void Post(Geracao geracao);
    void Put(Geracao geracao);
    void Delete(Geracao geracao);
}
