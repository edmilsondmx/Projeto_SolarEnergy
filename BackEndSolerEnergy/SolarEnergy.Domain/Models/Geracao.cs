using SolarEnergy.Domain.DTOs;

namespace SolarEnergy.Domain.Models;

public class Geracao
{
    public int Id { get; set; }
    public string Data { get; set; }
    public int Kw { get; set; }
    public int UnidadeId { get; set; }
    public virtual Unidade Unidade { get; set; }
    public Geracao(string data, int kw, int unidadeId)
    {
        Data = data;
        Kw = kw;
        UnidadeId = unidadeId;
    }
    public Geracao()
    {
        
    }
    public Geracao(GeracaoDto geracao)
    {
        Id = geracao.Id;
        Data = geracao.Data;
        Kw = geracao.Kw;
        UnidadeId = geracao.UnidadeId;
    }
    public void Update(GeracaoDto geracao)
    {
        Data = geracao.Data;
        Kw = geracao.Kw;
        UnidadeId = geracao.UnidadeId;
    }
}
