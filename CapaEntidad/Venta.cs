using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Venta
    {
        public int IDVENTA { get; set; }
        public Usuario oUSUARIO { get; set; }
        public string TIPODOCUMENTO { get; set; }
        public string NUMERODOCUMENTO { get; set; }
        public string DOCUMENTOCLIENTE { get; set; }
        public string NOMBRECLIENTE { get; set; }
        public decimal MONTOPAGO { get; set; }
        public decimal MONTOCAMBIO { get; set; }
        public decimal MONTOTOTAL { get; set; }
        public List<DetalleVenta> oDETALLEVENTA { get; set; }
        public bool ESTADO { get; set; }
        public string FECHAREGISTRO { get; set; }
    }
}
