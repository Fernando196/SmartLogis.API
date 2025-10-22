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
    /// <summary>
    /// Controlador para la gestión de clientes
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        /// <summary>
        /// Obtiene todos los clientes con filtros opcionales
        /// </summary>
        /// <param name="body">Filtros opcionales para la consulta</param>
        /// <returns>Lista de clientes</returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<ClienteDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetClientes([FromBody] FilterRequest? body)
        {
            var clientes = await _clienteService.GetAllAsync(body?.Filters);
            var clientesDto = clientes.Adapt<List<ClienteDto>>();
            return Ok(clientesDto);
        }
        /// <summary>
        /// Obtiene un cliente por su ID
        /// </summary>
        /// <param name="id">ID del cliente</param>
        /// <returns>Cliente encontrado</returns>
        [HttpGet("{id}", Name = "GetCliente")]
        [ProducesResponseType(typeof(ClienteDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetClienteById(int id)
        {
            var cliente = await _clienteService.GetByIdAsync(id);
            var clienteDto = cliente.Adapt<ClienteDto>();
            return Ok(clienteDto);
        }
        [HttpGet("{id}/envios", Name = "GetEnviosByCliente")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetEnviosByCliente(int id)
        {
            var envios = await _clienteService.GetEnviosByCliente(id);
            return Ok(envios);
        }
        /// <summary>
        /// Crea un nuevo cliente
        /// </summary>
        /// <param name="createClienteDto">Datos del cliente a crear</param>
        /// <returns>Cliente creado</returns>
        [HttpPost]
        [ProducesResponseType(typeof(ClienteDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateCliente([FromBody] CreateClienteDto createClienteDto)
        {
            if (createClienteDto == null)
            {
                return BadRequest(ModelState);
            }

            var cliente = createClienteDto.Adapt<Cliente>();
            var createdCliente = await _clienteService.CreateAsync(cliente);
            var createdClientDto = createdCliente.Adapt<ClienteDto>();
            return CreatedAtRoute("GetCliente", new { id = createdClientDto.IdCliente }, createdClientDto);
        }
        [HttpPut("{id}", Name = "UpdateCliente")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateCliente(int id, [FromBody] UpdateClienteDto updateClienteDto)
        {
            if (updateClienteDto == null)
            {
                return BadRequest(ModelState);
            }

            var cliente = updateClienteDto.Adapt<Cliente>();
            await _clienteService.UpdateAsync(id, cliente);
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

            await _clienteService.DeleteAsync(id);
            return NoContent();
        }
    }
}