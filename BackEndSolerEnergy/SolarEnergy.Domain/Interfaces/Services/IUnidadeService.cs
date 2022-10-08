using SolarEnergy.Domain.DTOs;

namespace SolarEnergy.Domain.Interfaces.Services;

public interface IUnidadeService
{
    IList<UnidadeDto> Get();
    UnidadeDto GetById(int id);
    void Post(UnidadeDto unidade);
    void Put(UnidadeDto unidade);
    void Delete(int id);
    
}
