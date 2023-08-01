using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class cnNegocio
    {
        private cdNegocio ocdNegocio = new cdNegocio();

        public Negocio ObtenerDatos()
        {
            return ocdNegocio.ObtenerDatos();
        }

        public bool GuardarDatos(Negocio negocio, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (negocio.NOMBRE == "" || negocio.NOMBRE.Length < 3)
            {
                Mensaje += "Es necesario el nombre del negocio y esta debe tener mas de 3 caracteres\n";
            }

            if (negocio.RUC == "" || negocio.RUC.Length < 5)
            {
                Mensaje += "Es necesario el nombre RUC del negocio y esta debe tener mas de 3 caracteres\n";
            }

            if (negocio.DIRECCION == "")
            {
                Mensaje += "Es necesario la direccion del negocio\n";
            }

            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return ocdNegocio.GuardarDatos(negocio, out Mensaje);
            }
        }

        public byte[] RecuperarLogo(out bool respuesta)
        {
            return ocdNegocio.RecuperarLogo(out respuesta); 
        }

        public bool ActualzarLogo(byte[] imagen, out string Mensaje)
        {
            return ocdNegocio.actualizarLogo(imagen, out Mensaje);
        }
    }
}
