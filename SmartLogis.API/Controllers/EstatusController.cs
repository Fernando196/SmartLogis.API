using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using SmartLogis.API.Models;
using SmartLogis.API.Models.Dtos;
using SmartLogis.API.Services.Interfaces;

namespace SmartLogis.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstatusController : ControllerBase
    {
        private readonly IEstatusService _estatusService;

        public EstatusController(IEstatusService estatusService)
        {
            _estatusService = estatusService;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetEstatus([FromBody] FilterRequest? body)
        {
            var estatus = await _estatusService.GetAllAsync(body?.Filters);
            var estatusDto = estatus.Adapt<List<EstatusDto>>();
            return Ok(estatusDto);
        }
        [HttpGet("{id}", Name = "GetCliente")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetClienteById(int id)
        {
            var estatus = await _estatusService.GetByIdAsync(id);
            var estatusDto = estatus.Adapt<EstatusDto>();
            return Ok(estatusDto);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateEstatus([FromBody] CreateEstatusDto createEstatusDto)
        {
            if (createEstatusDto == null)
            {
                return BadRequest(ModelState);
            }

            var estatus = createEstatusDto.Adapt<Estatus>();
            var createdEstatus = await _estatusService.CreateAsync(estatus);
            var createdEstatusDto = createdEstatus.Adapt<EstatusDto>();
            return CreatedAtRoute("GetCliente", new { id = createdEstatusDto.IdEstatus }, createdEstatusDto);
        }
        [HttpPut("{id}", Name = "UpdateEstatus")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateEstatus(int id, [FromBody] CreateEstatusDto updateEstatusDto)
        {
            if (updateEstatusDto == null)
            {
                return BadRequest(ModelState);
            }

            var estatus = updateEstatusDto.Adapt<Estatus>();
            await _estatusService.UpdateAsync(id, estatus);
            return NoContent();
        }
        [HttpDelete("{id}", Name = "DeleteCliente")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            if (id <= 0)
            {
                return BadRequest(ModelState);
            }

            await _estatusService.DeleteAsync(id);
            return NoContent();
        }
    }
}