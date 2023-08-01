using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class cnProveedor
    {
        private cdProveedor ocdProveedor = new cdProveedor();

        public List<Proveedor> ListarProveedor()
        {
            return ocdProveedor.ListarProveedores();
        }

        public int RegistrarProveedor(Proveedor proveedor, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (proveedor.DOCUMENTO == "" || proveedor.DOCUMENTO.Length < 3)
            {
                Mensaje += "Es necesario el documento del proveedor y esta debe tener mas de 3 caracteres\n";
            }

            if (proveedor.RAZONSOCIAL == "" || proveedor.RAZONSOCIAL.Length < 5)
            {
                Mensaje += "Es necesario la razon social del proveedor y esta debe tener mas de 3 caracteres\n";
            }

            if (proveedor.CORREO == "")
            {
                Mensaje += "Es necesario el correo del proveedor\n";
            }

            if (proveedor.TELEFONO == "" || proveedor.TELEFONO.Length < 5)
            {
                Mensaje += "Es necesario el telefono del proveedor y esta debe tener mas de 5 caracteres\n";
            }

            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return ocdProveedor.RegistrarProveedor(proveedor, out Mensaje);
            }
        }

        public bool EditarProveedor(Proveedor proveedor, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (proveedor.DOCUMENTO == "" || proveedor.DOCUMENTO.Length < 3)
            {
                Mensaje += "Es necesario el documento del proveedor y esta debe tener mas de 3 caracteres\n";
            }

            if (proveedor.RAZONSOCIAL == "" || proveedor.RAZONSOCIAL.Length < 5)
            {
                Mensaje += "Es necesario la razon social del proveedor y esta debe tener mas de 3 caracteres\n";
            }

            if (proveedor.CORREO == "")
            {
                Mensaje += "Es necesario el correo del proveedor\n";
            }

            if (proveedor.TELEFONO == "" || proveedor.TELEFONO.Length < 5)
            {
                Mensaje += "Es necesario el telefono del proveedor y esta debe tener mas de 5 caracteres\n";
            }

            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return ocdProveedor.EditarProveedor(proveedor, out Mensaje);
            }
        }

        public bool EliminarProveedor(Proveedor proveedor, out string Mensaje)
        {
            return ocdProveedor.EliminarProveedor(proveedor, out Mensaje);
        }
    }
}
