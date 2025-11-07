using Examen.Entity.DTOs;
using Examen.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Business.Services
{
    public interface ITiendaService
    {
        Task<TiendaResponseDto> CreateStoreAsync(CrearTiendaDto CreateStoreDto);
        Task<TiendaResponseDto> GetStoreByIdAsync(int id);
        Task<IEnumerable<TiendaResponseDto>> GetAllStoresAsync();
        Task DeleteStoreByIdAsync(int id);
        Task UpdateStoreByIdAsync(Tienda tienda);
    }
}
