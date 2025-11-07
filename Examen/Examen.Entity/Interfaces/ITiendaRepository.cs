using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examen.Entity.Entities;

namespace Examen.Entity.Interfaces
{
    public interface ITiendaRepository
    {
        Task<Tienda> GetByIdAsync(int id);
        Task<IEnumerable<Tienda>> GetAllAsync();
        Task<Tienda> CreateAsync(Tienda tienda);
        Task UpdateAsync(Tienda tienda);

        Task DeleteAsync(int id);
    }
}
