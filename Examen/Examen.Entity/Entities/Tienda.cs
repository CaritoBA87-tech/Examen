using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Entity.Entities
{
    public class Tienda
    {
        public int Id { get; set; }
        public string Sucursal { get; set; }
        public string Direccion { get; set; }
        public virtual ICollection<ArticuloTienda> ArticulosTienda { get; set; }
    }
}
