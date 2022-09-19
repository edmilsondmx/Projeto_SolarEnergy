using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SolarEnergy.Api.Data;
using SolarEnergy.Api.DTOs;
using SolarEnergy.Api.Models;
using SolarEnergy.Domain.Interfaces.Services;

namespace SolarEnergy.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UnidadesController : ControllerBase
{
    private readonly IUnidadeService _unidadeService;

    public UnidadesController(IUnidadeService unidadeService)
    {
        _unidadeService = unidadeService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_unidadeService.Get());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(
        [FromRoute] int id
    )
    {
        return Ok(_unidadeService.GetById(id));
    }

    [HttpPost]
    public IActionResult Post(
        [FromBody] UnidadeDto unidadeDto
    )
    {
        _unidadeService.Post(unidadeDto);
        return Created("api/unidades", unidadeDto);
    }
    
    [HttpPut("{id}")]
    public IActionResult Put(
        [FromBody] UnidadeDto unidadeDto,
        [FromRoute] int id
    )
    {
        unidadeDto.Id = id;
        _unidadeService.Put(unidadeDto);

        return Ok();   
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(
        [FromRoute] int id
    )
    {
        _unidadeService.Delete(id);
        return NoContent();
    }
}
