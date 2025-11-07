using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Entity.Entities
{
    public class ArticuloTienda
    {
        public int ArticuloID { get; set; }

        public int TiendaID { get; set; }
        public DateTime Fecha { get; set; }
        public int Stock { get; set; }
        public Articulo Articulo { get; set; }
        public Tienda Tienda { get; set; }
    }
}
