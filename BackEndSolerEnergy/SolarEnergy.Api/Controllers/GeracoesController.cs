using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SolarEnergy.Api.Data;
using SolarEnergy.Api.DTOs;
using SolarEnergy.Api.Models;

namespace SolarEnergy.Api.Controllers;

[ApiController]
[Route("api/geracoes")]
public class GeracoesController : ControllerBase
{
    private readonly SolarDbContext _context;

    public GeracoesController(SolarDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<List<Geracao>> Get(
        [FromQuery] int? unidadeId
    )
    {
        var query = _context.Geracoes.AsQueryable();

        if(unidadeId.HasValue)
            query = query.Where(g => g.UnidadeId == unidadeId);

        return Ok(query
            .ToList()
            );
    }

    [HttpGet("{id}")]
    public ActionResult<Geracao> GetById(
        [FromRoute] int id
    )
    {
        var geracao = _context.Geracoes
            .Include(g => g.Unidade)
            .Where(g => g.Id == id);

        if(geracao == null) return NotFound();

        return Ok(geracao);
    }

    [HttpPost]
    public ActionResult<Geracao> Post(
        [FromBody] GeracaoDto geracaoDto
    )
    {
        var unidade = _context.Unidades.Find(geracaoDto.UnidadeId);
        if(unidade == null) return BadRequest("Unidade não encontrada!");
        if(unidade.IsActive == false) return BadRequest("Unidade desativada!");

        var existeDataCadastrada = _context.Geracoes
            .Any(g => g.Data == geracaoDto.Data 
            && g.UnidadeId == geracaoDto.UnidadeId);
            
        if(existeDataCadastrada) return BadRequest("Data já cadastrada no sistema!");

        var geracao = new Geracao(
            geracaoDto.Data,
            geracaoDto.Kw,
            geracaoDto.UnidadeId
        );

        _context.Geracoes.Add(geracao);
        _context.SaveChanges();
        return Created("api/geracoes", geracao);
    }
    
    [HttpPut("{id}")]
    public ActionResult<Geracao> Put(
        [FromBody] GeracaoDto geracaoDto,
        [FromRoute] int id
    )
    {
        var geracao = _context.Geracoes.Find(id);
        var unidade = _context.Unidades.Find(geracaoDto.UnidadeId);
        if(geracao == null) return NotFound();
        if(unidade == null) return BadRequest();

        geracao.Data = geracaoDto.Data;
        geracao.Kw = geracaoDto.Kw;
        geracao.UnidadeId = geracaoDto.UnidadeId;

        _context.SaveChanges();
        return Ok(geracao);    
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(
        [FromRoute] int id
    )
    {
        var geracao = _context.Geracoes.Find(id);
        if(geracao == null) return NotFound();

        _context.Geracoes.Remove(geracao);
        _context.SaveChanges();

        return NoContent();
    }
}
