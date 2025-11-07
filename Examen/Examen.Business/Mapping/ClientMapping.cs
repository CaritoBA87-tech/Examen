using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Examen.Entity.Entities;

namespace Examen.Business.Mapping
{
    public class ClientMapping: Profile
    {
        public ClientMapping()
        {
            CreateMap<Cliente, Entity.DTOs.ClienteResponseDto>();
            CreateMap<Articulo, Entity.DTOs.ArticuloResponseDto>();
            CreateMap<Tienda, Entity.DTOs.TiendaResponseDto>();
            CreateMap<ArticuloTienda, Entity.DTOs.ArticleTiendaResponseDto>();
        }
    }
}
