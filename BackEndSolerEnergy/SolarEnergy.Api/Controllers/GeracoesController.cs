using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SolarEnergy.Api.Data;
using SolarEnergy.Api.DTOs;
using SolarEnergy.Api.Models;
using SolarEnergy.Domain.Interfaces.Services;

namespace SolarEnergy.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GeracoesController : ControllerBase
{
    private readonly IGeracaoService _geracaoService;

    public GeracoesController(IGeracaoService geracaoService)
    {
        _geracaoService = geracaoService;
    }

    [HttpGet]
    [Route("~/api/unidades/{idUnidade}/geracoes")]
    public IActionResult GetByUnidadeId(
        [FromRoute] int idUnidade
    )
    {
        var geracoes = _geracaoService.Get()
            .Where(g => g.UnidadeId == idUnidade)
            .ToList();

        return Ok(geracoes);
    }

    [HttpGet]
    public IActionResult Get()
    {
        
        return Ok(_geracaoService.Get());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(
        [FromRoute] int id
    )
    {
        return Ok(_geracaoService.GetById(id));
    }

    [HttpPost]
    public IActionResult Post(
        [FromBody] GeracaoDto geracaoDto
    )
    {
        _geracaoService.Post(geracaoDto);
        return Created("api/geracoes", geracaoDto);
    }
    
    [HttpPut("{id}")]
    public ActionResult<Geracao> Put(
        [FromBody] GeracaoDto geracaoDto,
        [FromRoute] int id
    )
    {
        geracaoDto.Id = id;
        _geracaoService.Put(geracaoDto);
        return Ok();    
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(
        [FromRoute] int id
    )
    {
        _geracaoService.Delete(id);

        return NoContent();
    }
}
