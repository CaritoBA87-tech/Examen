using Examen.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Entity.DTOs
{
    public class ArticleTiendaResponseDto
    {
        public int ArticuloID { get; set; }
        public int TiendaID { get; set; }
        public string Tienda { get; set; }
        public int Stock { get; set; }

        //public Tienda tienda { get; set; }
}
}
