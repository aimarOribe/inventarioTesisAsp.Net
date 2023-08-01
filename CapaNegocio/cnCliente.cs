using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class cnCliente
    {
        private cdCliente ocdCliente = new cdCliente();

        public List<Cliente> ListarClientes()
        {
            return ocdCliente.ListarClientes();
        }

        public int RegistrarCLiente(Cliente cliente, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (cliente.DOCUMENTO == "" || cliente.DOCUMENTO.Length < 3)
            {
                Mensaje += "Es necesario el documento del cliente y esta debe tener mas de 3 caracteres\n";
            }

            if (cliente.NOMBRECOMPLETO == "" || cliente.NOMBRECOMPLETO.Length < 5)
            {
                Mensaje += "Es necesario el nombre completo del cliente y esta debe tener mas de 3 caracteres\n";
            }

            if (cliente.CORREO == "")
            {
                Mensaje += "Es necesario el correo del cliente\n";
            }

            if (cliente.TELEFONO == "" || cliente.TELEFONO.Length < 8)
            {
                Mensaje += "Es necesario el telefono del cliente y esta debe tener mas de 5 caracteres\n";
            }

            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return ocdCliente.RegistrarCliente(cliente, out Mensaje);
            }
        }

        public bool EditarCliente(Cliente cliente, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (cliente.DOCUMENTO == "" || cliente.DOCUMENTO.Length < 3)
            {
                Mensaje += "Es necesario el documento del cliente y esta debe tener mas de 3 caracteres\n";
            }

            if (cliente.NOMBRECOMPLETO == "" || cliente.NOMBRECOMPLETO.Length < 5)
            {
                Mensaje += "Es necesario el nombre completo del cliente y esta debe tener mas de 3 caracteres\n";
            }

            if (cliente.CORREO == "")
            {
                Mensaje += "Es necesario el correo del cliente\n";
            }

            if (cliente.TELEFONO == "" || cliente.TELEFONO.Length < 8)
            {
                Mensaje += "Es necesario el telefono del cliente y esta debe tener mas de 5 caracteres\n";
            }

            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return ocdCliente.EditarCliente(cliente, out Mensaje);
            }
        }

        public bool EliminarCliente(Cliente cliente, out string Mensaje)
        {
            return ocdCliente.EliminarCliente(cliente, out Mensaje);
        }
    }
}
