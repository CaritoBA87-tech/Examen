using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Entity.Entities
{
    public class ClienteArticulo
    {
        public int ClienteID { get; set; }


        public int ArticuloID { get; set; }
        public DateTime Fecha { get; set; }
        public int Cantidad { get; set; }
        public Cliente Cliente { get; set; }
        public Articulo Articulo { get; set; }
    }
}
