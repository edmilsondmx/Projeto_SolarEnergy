using SolarEnergy.Api.DTOs;
using SolarEnergy.Api.Models;
using SolarEnergy.Domain.Interfaces.Repositories;
using SolarEnergy.Domain.Interfaces.Services;

namespace SolarEnergy.Domain.Services;

public class GeracaoService : IGeracaoService
{
    private readonly IGeracaoRepository _geracaoRepository;
    public GeracaoService(IGeracaoRepository geracaoRepository)
    {
        _geracaoRepository = geracaoRepository;
    }

    public void Delete(int id)
    {
        Geracao geracaoDb = _geracaoRepository.GetById(id);
        _geracaoRepository.Delete(geracaoDb);
    }

    public IList<GeracaoDto> Get()
    {
        return _geracaoRepository.Get()
        .Select(g => new GeracaoDto(g))
        .ToList();
    }

    public GeracaoDto GetById(int id)
    {
        return new GeracaoDto(_geracaoRepository.GetById(id));
    }

    public void Post(GeracaoDto geracao)
    {
        _geracaoRepository.Post(new Geracao(geracao));
    }

    public void Put(GeracaoDto geracao)
    {
        Geracao geracaoDb = _geracaoRepository.GetById(geracao.Id);
        geracaoDb.Update(geracao);

        _geracaoRepository.Put(geracaoDb);
    }
}
