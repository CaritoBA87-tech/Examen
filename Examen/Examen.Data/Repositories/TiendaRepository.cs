using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examen.Data.AppDbContext;
using Examen.Entity.Entities;
using Examen.Entity.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Examen.Data.Repositories
{
    public class TiendaRepository: ITiendaRepository
    {
        private readonly ApplicationDbContext _context;

        public TiendaRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Tienda> CreateAsync(Tienda tienda)
        {
            _context.Tiendas.Add(tienda);
            await _context.SaveChangesAsync();
            return tienda;
        }

        public async Task DeleteAsync(int id)
        {
            var tienda = await _context.Tiendas.FindAsync(id);

            if (tienda != null)
            {
                _context.Tiendas.Remove(tienda);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Tienda>> GetAllAsync()
        {
            return await _context.Tiendas.ToListAsync();
        }

        public async Task<Tienda> GetByIdAsync(int id)
        {
            var tienda = _context.Tiendas
                .FirstOrDefault(o => o.Id == id);

            return tienda;
        }

        public async Task UpdateAsync(Tienda tienda)
        {
            _context.Tiendas.Update(tienda);
            await _context.SaveChangesAsync();
        }
    }
}
