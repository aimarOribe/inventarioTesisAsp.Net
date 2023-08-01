using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Compra
    {
        public int IDCOMPRA { get; set; }
        public Usuario oUSUARIO { get; set; }
        public Proveedor oPROVEEDOR { get; set; }
        public string TIPODOCUMENTO { get; set; }
        public string NUMERODOCUMENTO { get; set; }
        public decimal MONTOTOTAL { get; set; }
        public List<DetalleCompra> oDETALLECOMPRA {get; set;}
        public string FECHAREGISTRO { get; set; }
    }
}
