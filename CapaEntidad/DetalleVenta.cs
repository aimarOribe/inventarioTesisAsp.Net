using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class DetalleVenta
    {
        public int IDDETALLEVENTA { get; set; }
        public Producto oPRODUCTO { get; set; }
        public decimal PRECIOVENTA { get; set; }
        public int CANTIDAD { get; set; }
        public decimal SUBTOTAL { get; set; }
        public bool ESTADO { get; set; }
        public string FECHAREGISTRO { get; set; }
    }
}
