using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Proveedor
    {
        public int IDPROVEEDOR { get; set; }
        public string DOCUMENTO { get; set; }
        public string RAZONSOCIAL { get; set; }
        public string CORREO { get; set; }
        public string TELEFONO { get; set; }
        public bool ESTADO { get; set; }
        public string FECHAREGISTRO { get; set; }
    }
}
