using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Examen.Business.Services;
using Examen.Entity.DTOs;
using Examen.Entity.Entities;

namespace Examen.Front.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticuloService _articleService;

        public ArticlesController(IArticuloService articleService)
        {
            _articleService = articleService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArticuloResponseDto>>> GetAllArticles()
        {
            var articulos = await _articleService.GetAllArticlesAsync();
            return Ok(articulos);
        }


        [HttpGet("{id}")]
        //[Route("GetArticle")]
        public async Task<ActionResult<ArticuloResponseDto>> GetArticle(int id)
        {
            try
            {
                var articulo = await _articleService.GetArticleByIdAsync(id);
                return Ok(articulo);
            }

            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [Route("getTiendasArticulo/{id}")]
        public async Task<ActionResult<IEnumerable<ArticleTiendaResponseDto>>>  getTiendasArticulo(int id)
        {
            try
            {
                var articulo = await _articleService.getTiendasArticulo(id);
                return Ok(articulo);
            }

            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpPost]
        [Route("updateTiendasArticulo")]
        public async Task<IActionResult> updateTiendasArticulo(List<ArticleTiendaResponseDto> conjunto)
        {

            await _articleService.updateTiendasArticulo(conjunto);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<ArticuloResponseDto>> CreateArticle([FromBody] CrearArticuloDto crearArticuloDto)
        {
            try
            {
                var articulo = await _articleService.CreateArticleAsync(crearArticuloDto);
                return CreatedAtAction(nameof(GetArticle), new { id = articulo.Id }, articulo);
            }

            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error interno del servidor" });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ArticuloResponseDto>> DeleteArticle(int id)
        {
            await _articleService.DeleteArticleByIdAsync(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutArticle(int id, Articulo articulo)
        {
            if (id != articulo.Id)
            {
                return BadRequest();
            }

            await _articleService.UpdateArticleByIdAsync(articulo);
            return NoContent();
        }

        [Route("GetStoresByArticleId/{id}")]
        public async Task<ActionResult<IEnumerable<ArticleTiendaResponseDto>>> GetStoresByArticleId(int id)
        {
            try
            {
                var tiendas = await _articleService.GetStoresByArticleIdAsync(id);
                return Ok(tiendas);
            }

            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }


    }
}
