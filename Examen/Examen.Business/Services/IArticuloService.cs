using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examen.Entity.DTOs;
using Examen.Entity.Entities;

namespace Examen.Business.Services
{
    public interface IArticuloService
    {
        Task<ArticuloResponseDto> CreateArticleAsync(CrearArticuloDto CreateArticleeDto);
        Task<ArticuloResponseDto> GetArticleByIdAsync(int id);
        Task<IEnumerable<ArticuloResponseDto>> GetAllArticlesAsync();
        Task DeleteArticleByIdAsync(int id);
        Task UpdateArticleByIdAsync(Articulo articulo);

        Task<IEnumerable<ArticleTiendaResponseDto>> getTiendasArticulo(int id);

        Task updateTiendasArticulo(List<ArticleTiendaResponseDto> conjunto);

        Task<IEnumerable<TiendaResponseDto>> GetStoresByArticleIdAsync(int id);
    }
}
