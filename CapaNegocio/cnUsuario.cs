using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class cnUsuario
    {
        private cdUsuario ocdUsuario = new cdUsuario();

        public List<Usuario> ListarUsuarios()
        {
            return ocdUsuario.ListarUsuarios();
        }

        public int RegistrarUsuario(Usuario usuario, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (usuario.DOCUMENTO == "" || usuario.DOCUMENTO.Length < 3 )
            {
                Mensaje += "Es necesario el documento del usuario y esta debe tener mas de 3 caracteres\n";
            }

            if (usuario.NOMBRECOMPLETO == "" || usuario.NOMBRECOMPLETO.Length < 5)
            {
                Mensaje += "Es necesario el nombre completo del usuario y esta debe tener mas de 3 caracteres\n";
            }

            if (usuario.CORREO == "")
            {
                Mensaje += "Es necesario el correo del usuario\n";
            }

            if (usuario.CLAVE == "" || usuario.CLAVE.Length < 5)
            {
                Mensaje += "Es necesario la clave del usuario y esta debe tener mas de 5 caracteres\n";
            }

            if(Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return ocdUsuario.RegistrarUsuario(usuario, out Mensaje);
            }  
        }

        public bool EditarUsuario(Usuario usuario, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (usuario.DOCUMENTO == "")
            {
                Mensaje += "Es necesario el documento del usuario\n";
            }

            if (usuario.NOMBRECOMPLETO == "")
            {
                Mensaje += "Es necesario el nombre completo del usuario\n";
            }

            if (usuario.CORREO == "")
            {
                Mensaje += "Es necesario el correo del usuario\n";
            }

            if (usuario.CLAVE == "")
            {
                Mensaje += "Es necesario la clave del usuario\n";
            }

            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return ocdUsuario.EditarUsuario(usuario, out Mensaje);
            }
        }

        public bool EliminarUsuario(Usuario usuario, out string Mensaje)
        {
            return ocdUsuario.EliminarUsuario(usuario, out Mensaje);
        }
    }
}
