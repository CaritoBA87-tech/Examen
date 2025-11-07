using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Entity.Entities
{
    public class Articulo
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string Imagen { get; set; }
        public int Stock { get; set; }
        public virtual ICollection<ClienteArticulo> ClienteArticulos { get; set; }
        public virtual ICollection<ArticuloTienda> ArticulosTienda { get; set; }
    }
}
