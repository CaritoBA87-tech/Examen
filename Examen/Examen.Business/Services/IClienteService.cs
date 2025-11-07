using Examen.Entity.DTOs;
using Examen.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Examen.Business.Services
{
    public interface IClienteService
    {
        Task<ClienteResponseDto> CreateClientAsync(CrearClienteDto CreateClienteDto);
        Task<ClienteResponseDto> GetClientByIdAsync(int id);
        Task<IEnumerable<ClienteResponseDto>> GetAllClientsAsync();
        Task DeleteClientByIdAsync(int id);
        Task UpdateClientByIdAsync(Cliente cliente);
    }
}
