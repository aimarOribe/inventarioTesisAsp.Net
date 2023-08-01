using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Categoria
    {
        public int IDCATEGORIA { get; set; }
        public string DESCRIPCION { get; set; }
        public Medida oMEDIDA { get; set; }
        public bool ESTADO { get; set; }
        public string FECHAREGISTRO { get; set; }
    }
}
