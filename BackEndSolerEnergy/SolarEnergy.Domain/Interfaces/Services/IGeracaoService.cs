using SolarEnergy.Api.DTOs;

namespace SolarEnergy.Domain.Interfaces.Services;

public interface IGeracaoService
{
    IList<GeracaoDto> Get();
    GeracaoDto GetById(int id);
    void Post(GeracaoDto unidade);
    void Put(GeracaoDto unidade);
    void Delete(int id);
}
