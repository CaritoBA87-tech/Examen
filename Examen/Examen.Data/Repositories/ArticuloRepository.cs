using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examen.Entity.Entities;
using Examen.Entity.Interfaces;
using Examen.Data.AppDbContext;
using Microsoft.EntityFrameworkCore;
using Examen.Entity.DTOs;

namespace Examen.Data.Repositories
{
    public class ArticuloRepository : IArticuloRepository
    {
        private readonly ApplicationDbContext _context;

        public ArticuloRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Articulo> CreateAsync(Articulo articulo)
        {
            _context.Articulos.Add(articulo);
            await _context.SaveChangesAsync();
            return articulo;
        }

        public async Task CreateAsyncArticuloTienda(List<ArticuloTienda> articuloTienda)
        {
            foreach (var item in articuloTienda)
            {
                _context.ArticulosTiendas.Add(item);
                await _context.SaveChangesAsync();
            } 

        }

        public async Task DeleteAsync(int id)
        {
            var articulo = await _context.Articulos.FindAsync(id);

            if (articulo != null)
            {
                _context.Articulos.Remove(articulo);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Articulo>> GetAllAsync()
        {
            return await _context.Articulos.Include(x => x.ArticulosTienda).ToListAsync();
        }

        public async Task<Articulo> GetByIdAsync(int id)
        {
            var articulo = _context.Articulos
                .Include(o => o.ArticulosTienda)
                .FirstOrDefault(o => o.Id == id);
                

            return articulo;
        }

        public async Task UpdateAsync(Articulo articulo)
        {
            _context.Articulos.Update(articulo);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ArticuloTienda>> getTiendasArticulo(int id)
        {
            return await _context.ArticulosTiendas.Where(x=> x.ArticuloID == id).ToListAsync();
        }

        public async Task updateTiendasArticulo(List<ArticleTiendaResponseDto> conjunto)
        {
            if (conjunto.Count > 0)
            {
                var articuloID = conjunto.Select(x => x.ArticuloID).FirstOrDefault();

                var itemsToDelete = _context.ArticulosTiendas.Where(item => item.ArticuloID == articuloID).ToList();

                foreach (var item in itemsToDelete)
                {
                    _context.ArticulosTiendas.Remove(item);
                    await _context.SaveChangesAsync();
                }

                foreach (var item in conjunto)
                {
                    if (item.TiendaID > 0)
                    {
                        _context.ArticulosTiendas.Add(new ArticuloTienda { ArticuloID = item.ArticuloID, TiendaID = item.TiendaID, Fecha = DateTime.Now, Stock = item.Stock });
                        await _context.SaveChangesAsync();
                    }
                }
            }

        }

        /*public async Task<IEnumerable<Tienda>> GetStoresByArticleIdAsync(int id)
        {
            var stores = from a in _context.ArticulosTiendas
                         join b in _context.Articulos
                         on a.ArticuloID equals b.Id
                         where b.Id == id
                         select new Tienda { Id = a.Tienda.Id, Sucursal = a.Tienda.Sucursal };

            return stores;
        }*/

        public async Task<IEnumerable<ArticuloTienda>> GetStoresByArticleIdAsync(int id)
        {
            return await _context.ArticulosTiendas.Where(x => x.ArticuloID == id).Include(x => x.Tienda).ToListAsync();

        }
    }
}

