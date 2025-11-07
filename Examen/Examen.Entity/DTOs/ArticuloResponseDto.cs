using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examen.Entity.Entities;

namespace Examen.Entity.DTOs
{
    public class ArticuloResponseDto
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string Imagen { get; set; }
        public int Stock { get; set; }

        //public List<ArticleTiendaResponseDto> ArticulosTienda { get; set; }
    } 
}
