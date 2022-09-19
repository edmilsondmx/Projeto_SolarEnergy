using SolarEnergy.Api.DTOs;
using SolarEnergy.Api.Models;
using SolarEnergy.Domain.Exceptions;
using SolarEnergy.Domain.Interfaces.Repositories;
using SolarEnergy.Domain.Interfaces.Services;

namespace SolarEnergy.Domain.Services;

public class GeracaoService : IGeracaoService
{
    private readonly IGeracaoRepository _geracaoRepository;
    private readonly IUnidadeRepository _unidadeRepository;
    public GeracaoService(IGeracaoRepository geracaoRepository, IUnidadeRepository unidadeRepository)
    {
        _geracaoRepository = geracaoRepository;
        _unidadeRepository = unidadeRepository;
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
        if(UnidadeEhAtiva(geracao.UnidadeId))
            throw new UnidadeInativaException("Unidade Inativa!");
        
        if(DataCadastrada(geracao))
            throw new DataJaCadastradaException("Data já cadastrada no sistema!");

        _geracaoRepository.Post(new Geracao(geracao));
    }
    private bool DataCadastrada(GeracaoDto geracao)
    {
        return _geracaoRepository.Get()
            .Any(g => g.Data == geracao.Data && g.Id == geracao.Id);
    }
    private bool UnidadeEhAtiva(int idUnidade)
    {
        var unidade = _unidadeRepository.GetById(idUnidade);

        return(unidade.IsActive != true);
    }

    public void Put(GeracaoDto geracao)
    {
        Geracao geracaoDb = _geracaoRepository.GetById(geracao.Id);
        geracaoDb.Update(geracao);

        _geracaoRepository.Put(geracaoDb);
    }
}
