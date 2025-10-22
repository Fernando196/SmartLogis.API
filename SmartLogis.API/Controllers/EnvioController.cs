using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using SmartLogis.API.Models.Dtos;
using SmartLogis.API.Services.Interfaces;

namespace SmartLogis.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EnvioController : ControllerBase
{
    private readonly IEnvioService _envioService;

    public EnvioController(IEnvioService envioService)
    {
        _envioService = envioService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<Models.Envio>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllAsync([FromBody] FilterRequest? filters)
    {
        var envios = await _envioService.GetAllAsync(filters?.Filters);
        var enviosDto = envios.Adapt<List<EnvioDto>>();
        return Ok(enviosDto);
    }
    [HttpGet("{id}", Name = "GetEnvioById")]
    [ProducesResponseType(typeof(EnvioDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var envio = await _envioService.GetByIdAsync(id);
        if (envio == null) return NotFound();

        var envioDto = envio.Adapt<EnvioDto>();
        return Ok(envioDto);
    }
    [HttpPost]
    [ProducesResponseType(typeof(CreateEnvioDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateAsync([FromBody] CreateEnvioDto envioDto)
    {
        if (envioDto == null)
            return BadRequest(ModelState);
        var envio = envioDto.Adapt<Models.Envio>();
        var createdEnvio = await _envioService.CreateAsync(envio);
        var createdEnvioDto = createdEnvio.Adapt<EnvioDto>();
        return CreatedAtRoute("GetEnvioById", new { id = createdEnvioDto.IdEnvio }, createdEnvioDto);
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _envioService.DeleteAsync(id);
        return NoContent();
    }
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateEnvioDto envioDto)
    {
        if (envioDto == null)
            return BadRequest(ModelState);

        var envio = envioDto.Adapt<Models.Envio>();
        await _envioService.UpdateAsync(id, envio);
        return NoContent();
    }
}