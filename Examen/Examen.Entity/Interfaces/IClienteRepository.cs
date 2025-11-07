using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examen.Entity.Entities;

namespace Examen.Entity.Interfaces
{
    public interface IClienteRepository
    {
        Task<Cliente> GetByIdAsync(int id);
        Task<IEnumerable<Cliente>> GetAllAsync();
        Task<Cliente> CreateAsync(Cliente cliente);
        Task UpdateAsync(Cliente cliente);

        Task DeleteAsync(int id);
    }
}
