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
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public ClienteService(IClienteRepository clienteRepository, IMapper mapper) 
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<ClienteResponseDto> CreateClientAsync(CrearClienteDto crearClienteDto)
        {
            var cliente = new Cliente
            {
                Nombre = crearClienteDto.Nombre,
                Apellido = crearClienteDto.Apellido,
                Direccion = crearClienteDto.Direccion

            };

            var createClient = await _clienteRepository.CreateAsync(cliente);
            return _mapper.Map<ClienteResponseDto>(createClient);
        }

        public async Task<ClienteResponseDto> GetClientByIdAsync(int id)
        {
            var cliente = await _clienteRepository.GetByIdAsync(id);

            if (cliente == null)
                throw new KeyNotFoundException($"Cliente no encontrado");

            return _mapper.Map<ClienteResponseDto>(cliente);
        }

        public async Task<IEnumerable<ClienteResponseDto>> GetAllClientsAsync()
        {
            var clientes = await _clienteRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ClienteResponseDto>>(clientes);
        }

        public async Task DeleteClientByIdAsync(int id)
        {
            await _clienteRepository.DeleteAsync(id);
        }

        public async Task UpdateClientByIdAsync(Cliente cliente)
        {
            await _clienteRepository.UpdateAsync(cliente);
        }
    }
}
