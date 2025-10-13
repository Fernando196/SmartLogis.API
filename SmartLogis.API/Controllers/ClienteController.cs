using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using SmartLogis.API.Models;
using SmartLogis.API.Models.Dtos;
using SmartLogis.API.Services;
using SmartLogis.API.Services.Interfaces;

namespace SmartLogis.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetClientes()
        {
            var clientes = await _clienteService.GetAllAsync();
            var clientesDto = clientes.Adapt<List<ClienteDto>>();
            return Ok(clientesDto);
        }
        [HttpGet("{id}", Name = "GetCliente")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetClienteById(int id)
        {
            var cliente = await _clienteService.GetByIdAsync(id);
            var clienteDto = cliente.Adapt<ClienteDto>();
            return Ok(clienteDto);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateCliente([FromBody] CreateClienteDto createClienteDto)
        {
            if (createClienteDto == null)
            {
                return BadRequest(ModelState);
            }

            var cliente = createClienteDto.Adapt<Cliente>();
            if (!await _clienteService.CreateAsync(cliente))
            {
                return StatusCode(500, "Ocurrio un problema al crear el cliente");
            }
            var createdClientDto = cliente.Adapt<ClienteDto>();
            return CreatedAtRoute("GetCliente", new { id = createdClientDto.IdCliente }, createdClientDto);
        }
    }
}