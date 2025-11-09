using Examen.Business.Services;
using Examen.Entity.DTOs;
using Examen.Entity.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen.Front.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoresController : ControllerBase
    {
        private readonly ITiendaService _storeService;

        public StoresController(ITiendaService storeService)
        {
            _storeService = storeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TiendaResponseDto>>> GetAllStores()
        {
            var tiendas = await _storeService.GetAllStoresAsync();
            return Ok(tiendas);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<TiendaResponseDto>> GetStore(int id)
        {
            try
            {
                var tienda = await _storeService.GetStoreByIdAsync(id);
                return Ok(tienda);
            }

            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult<TiendaResponseDto>> CreateStore([FromBody] CrearTiendaDto crearTiendaDto)
        {
            try
            {
                var tienda = await _storeService.CreateStoreAsync(crearTiendaDto);
                return CreatedAtAction(nameof(GetStore), new { id = tienda.Id }, tienda);
            }

            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error interno del servidor" });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TiendaResponseDto>> DeleteStore(int id)
        {
            await _storeService.DeleteStoreByIdAsync(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutStore(int id, Tienda tienda)
        {
            if (id != tienda.Id)
            {
                return BadRequest();
            }

            await _storeService.UpdateStoreByIdAsync(tienda);
            return NoContent();
        }


    }
}

