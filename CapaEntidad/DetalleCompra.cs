using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class DetalleCompra
    {
        public int IDDETALLECOMPRA { get; set; }
        public Producto oPRODUCTO { get; set; }
        public decimal PRECIOCOMPRA { get; set; }
        public decimal PRECIOVENTA { get; set; }
        public int CANTIDAD { get; set; }
        public decimal MONTOTOTAL { get; set; }
        public string FECHAREGISTRO { get; set; }
    }
}
