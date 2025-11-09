using Examen.Entity.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Examen.Entity.DTOs;
using Examen.Entity.Entities;

namespace Examen.Business.Services
{
    public class TiendaService : ITiendaService
    {
        private readonly ITiendaRepository _tiendaRepository;
        private readonly IMapper _mapper;

        public TiendaService(ITiendaRepository tiendaRepository, IMapper mapper)
        {
            _tiendaRepository = tiendaRepository;
            _mapper = mapper;
        }

        public async Task<TiendaResponseDto> CreateStoreAsync(CrearTiendaDto crearTiendaDto)
        {
            var tienda = new Tienda
            {
                Sucursal = crearTiendaDto.Sucursal,
                Direccion = crearTiendaDto.Direccion

            };

            var createStore = await _tiendaRepository.CreateAsync(tienda);
            return _mapper.Map<TiendaResponseDto>(createStore);
        }

        public async Task<TiendaResponseDto> GetStoreByIdAsync(int id)
        {
            var tienda = await _tiendaRepository.GetByIdAsync(id);

            if (tienda == null)
                throw new KeyNotFoundException($"Tienda no encontrada");

            return _mapper.Map<TiendaResponseDto>(tienda);
        }

        public async Task<IEnumerable<TiendaResponseDto>> GetAllStoresAsync()
        {
            var tiendas = await _tiendaRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<TiendaResponseDto>>(tiendas);
        }


        public async Task DeleteStoreByIdAsync(int id)
        {
            await _tiendaRepository.DeleteAsync(id);
        }

        public async Task UpdateStoreByIdAsync(Tienda tienda)
        {
            await _tiendaRepository.UpdateAsync(tienda);
        }

    }
}
