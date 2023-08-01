using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CapaEntidad
{
    public class Cliente
    {
        public int IDCLIENTE { get; set; }
        public string DOCUMENTO { get; set; }
        public string NOMBRECOMPLETO { get; set; }
        public string CORREO { get; set; }
        public string TELEFONO { get; set; }
        public bool ESTADO { get; set; }
        public string FECHAREGISTRO { get; set; }
    }
}
