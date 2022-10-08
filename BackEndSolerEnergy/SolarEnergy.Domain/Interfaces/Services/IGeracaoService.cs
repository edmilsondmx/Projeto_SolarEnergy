using SolarEnergy.Domain.DTOs;

namespace SolarEnergy.Domain.Interfaces.Services;

public interface IGeracaoService
{
    IList<GeracaoDto> Get();
    GeracaoDto GetById(int id);
    void Post(GeracaoDto geracao);
    void Put(GeracaoDto geracao);
    void Delete(int id);
}
