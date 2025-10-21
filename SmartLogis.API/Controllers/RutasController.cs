using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using SmartLogis.API.Models;
using SmartLogis.API.Models.Dtos;
using SmartLogis.API.Services.Interfaces;

namespace SmartLogis.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RutasController : ControllerBase
{
    private readonly IRutasService _rutasService;

    public RutasController(IRutasService rutasService)
    {
        _rutasService = rutasService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetRutas([FromBody] FilterRequest? filters)
    {
        var rutas = await _rutasService.GetAllAsync(filters?.Filters);
        var rutasDto = rutas.Adapt<List<RutasDto>>();
        return Ok(rutasDto);
    }
    [HttpGet("{id}", Name = "GetRuta")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetRutaById(int id)
    {
        var ruta = await _rutasService.GetByIdAsync(id);
        var rutaDto = ruta.Adapt<RutasDto>();
        return Ok(rutaDto);
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateRuta([FromBody] CreateRutasDto createRutasDto)
    {
        if (createRutasDto == null)
        {
            return BadRequest(ModelState);
        }

        var ruta = createRutasDto.Adapt<Rutas>();
        var createdRuta = await _rutasService.CreateAsync(ruta);
        var createdRutaDto = createdRuta.Adapt<RutasDto>();

        return CreatedAtRoute("GetRuta", new { id = createdRutaDto.IdRuta }, createdRutaDto);
    }
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdateRuta(int id, [FromBody] CreateRutasDto updateRutasDto)
    {
        if (updateRutasDto == null)
        {
            return BadRequest(ModelState);
        }

        var ruta = updateRutasDto.Adapt<Rutas>();
        await _rutasService.UpdateAsync(id, ruta);

        return NoContent();
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteRuta(int id)
    {
        if (id <= 0)
        {
            return BadRequest(ModelState);
        }
        
        await _rutasService.DeleteAsync(id);
        return NoContent();
    }
}