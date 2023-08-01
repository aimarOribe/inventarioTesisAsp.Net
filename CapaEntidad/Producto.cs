using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Producto
    {
        public int IDPRODUCTO { get; set; }
        public string CODIGO { get; set; }
        public string NOMBRE { get; set; }
        public string DESCRIPCION { get; set; }
        public Categoria oCATEGORIA { get; set; }
        public int STOCK { get; set; }
        public decimal PRECIOCOMPRA { get; set; }
        public decimal PRECIOVENTA { get; set; }
        public byte[] IMAGEN { get; set; }
        public bool ESTADO { get; set; }
        public string FECHAREGISTRO { get; set; }
    }
}
