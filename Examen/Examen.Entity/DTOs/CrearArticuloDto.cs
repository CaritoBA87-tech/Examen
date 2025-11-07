using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Entity.DTOs
{
    public class CrearArticuloDto
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public decimal precio { get; set; }
        public string imagen { get; set; }
        public int stock { get; set; }
        public List<int> TiendasIDs { get; set; }
    }
}
