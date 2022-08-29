using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SolarEnergy.Api.Data;
using SolarEnergy.Api.DTOs;
using SolarEnergy.Api.Models;

namespace SolarEnergy.Api.Controllers;

[ApiController]
[Route("api/unidades")]
public class UnidadesController : ControllerBase
{
    private readonly SolarDbContext _context;

    public UnidadesController(SolarDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<List<Unidade>> Get()
    {
        return _context.Unidades.ToList();
    }

    [HttpGet("{id}")]
    public ActionResult<Unidade> GetById(
        [FromRoute] int id
    )
    {
        var unidade = _context.Unidades
            .Include(u => u.Geracoes)
            .Where(u => u.Id == id)
            .FirstOrDefault();

        if(unidade == null) return NotFound();

        return Ok(unidade);
    }

    [HttpPost]
    public ActionResult<Unidade> Post(
        [FromBody] UnidadeDto unidadeDto
    )
    {
        var unidade = new Unidade(
            unidadeDto.Apelido,
            unidadeDto.Local,
            unidadeDto.Marca,
            unidadeDto.Modelo,
            unidadeDto.IsActive
        );

        _context.Unidades.Add(unidade);
        _context.SaveChanges();
        return Created("api/unidades", unidade);
    }
    
    [HttpPut("{id}")]
    public ActionResult<Unidade> Put(
        [FromBody] UnidadeDto unidadeDto,
        [FromRoute] int id
    )
    {
        var unidade = _context.Unidades.Find(id);
        if(unidade == null) return NotFound();

        unidade.Apelido = unidadeDto.Apelido;
        unidade.Local = unidadeDto.Local;
        unidade.Marca = unidadeDto.Marca;
        unidade.Modelo = unidadeDto.Modelo;
        unidade.IsActive = unidadeDto.IsActive;

        _context.SaveChanges();
        return Ok(unidade);    
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(
        [FromRoute] int id
    )
    {
        var unidade = _context.Unidades.Find(id);
        if(unidade == null) return NotFound();

        _context.Unidades.Remove(unidade);
        _context.SaveChanges();

        return NoContent();
    }
}
