using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examen.Entity.DTOs;
using Examen.Entity.Entities;

namespace Examen.Entity.Interfaces
{
    public interface IArticuloRepository
    {
        Task<Articulo> GetByIdAsync(int id);
        Task<IEnumerable<Articulo>> GetAllAsync();
        Task<Articulo> CreateAsync(Articulo articulo);
        Task UpdateAsync(Articulo articulo);

        Task DeleteAsync(int id);

        Task CreateAsyncArticuloTienda(List<ArticuloTienda> articulo);

        Task<IEnumerable<ArticuloTienda>> getTiendasArticulo(int id);

        Task updateTiendasArticulo(List<ArticleTiendaResponseDto> conjunto);

        Task<IEnumerable<Tienda>> GetStoresByArticleIdAsync(int id);
    }
}
