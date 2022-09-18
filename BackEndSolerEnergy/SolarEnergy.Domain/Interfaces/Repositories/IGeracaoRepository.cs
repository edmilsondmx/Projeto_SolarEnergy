using SolarEnergy.Api.Models;

namespace SolarEnergy.Domain.Interfaces.Repositories;

public interface IGeracaoRepository
{
    IList<Geracao> Get();
    Geracao GetById(int id);
    void Post(Geracao unidade);
    void Put(Geracao unidade);
    void Delete(int id);
}
