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
public class TransportistaController : ControllerBase
{
    private readonly ITransportistaService transportistaService;
    public TransportistaController(ITransportistaService transportistaService)
    {
        this.transportistaService = transportistaService;
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetTransportistas([FromBody] FilterRequest? body)
    {
        var transportistas = await transportistaService.GetAllAsync(body?.Filters);
        return Ok(transportistas);
    }
    [HttpGet("{id}", Name = "GetTransportista")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetTransportistaById(int id)
    {
        var transportista = await transportistaService.GetByIdAsync(id);
        var transportistaDto = transportista.Adapt<TransportistaDto>();
        return Ok(transportistaDto);
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateTransportista([FromBody] CreateTransportistaDto createTransportistaDto)
    {
        if (createTransportistaDto == null)
        {
            return BadRequest(ModelState);
        }

        var transportista = createTransportistaDto.Adapt<Transportista>();
        var createdTransportista = await transportistaService.CreateAsync(transportista);
        var createdTransportistaDto = createdTransportista.Adapt<TransportistaDto>();

        return CreatedAtRoute("GetTransportista", new { id = createdTransportistaDto.IdTransportista }, createdTransportistaDto);
    }
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateTransportista(int id, [FromBody] UpdateTransportistaDto updateTransportistaDto)
    {
        if (updateTransportistaDto == null)
        {
            return BadRequest(ModelState);
        }

        var transportista = updateTransportistaDto.Adapt<Transportista>();
        await transportistaService.UpdateAsync(id,transportista);

        return NoContent();
    }
}