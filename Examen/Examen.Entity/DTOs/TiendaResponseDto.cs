using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Entity.DTOs
{
    public class TiendaResponseDto
    {
        public int Id { get; set; }
        public string Sucursal { get; set; }
        public string Direccion { get; set; }
        public List<ArticleTiendaResponseDto> ArticulosTienda { get; set; }
    }
}
