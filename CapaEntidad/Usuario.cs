using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Usuario
    {
        public int IDUSUARIO { get; set; }
        public string DOCUMENTO { get; set; }
        public string NOMBRECOMPLETO { get; set; }
        public string CORREO { get; set; }
        public string CLAVE { get; set; }
        public Rol oROL { get; set; }
        public bool ESTADO { get; set;}
        public string FECHAREGISTRO { get; set; }
    }
}
