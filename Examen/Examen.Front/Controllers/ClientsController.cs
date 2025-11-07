using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Examen.Business.Services;
using Microsoft.Extensions.Logging;
using Examen.Entity.DTOs;
using Examen.Entity.Entities;

namespace Examen.Front.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClienteService _clientService;

        public ClientsController(IClienteService clientService, ILogger<ClientsController> logger)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteResponseDto>>> GetAllClients()
        {
            var clientes = await _clientService.GetAllClientsAsync();
            return Ok(clientes);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteResponseDto>> GetClient(int id)
        {
            try
            {
                var cliente = await _clientService.GetClientByIdAsync(id);
                return Ok(cliente);
            }

            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult<ClienteResponseDto>> CreateClient([FromBody] CrearClienteDto crearClienteDto)
        {
            try
            {
                var cliente = await _clientService.CreateClientAsync(crearClienteDto);
                return CreatedAtAction(nameof(GetClient), new { id = cliente.Id }, cliente);
            }

            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error interno del servidor" });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ClienteResponseDto>> DeleteClient(int id)
        {
            await _clientService.DeleteClientByIdAsync(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutClient(int id, Cliente cliente)
        {
            if (id != cliente.Id)
            {
                return BadRequest();
            }

            await _clientService.UpdateClientByIdAsync(cliente);
            return NoContent();
        }

    }
}
