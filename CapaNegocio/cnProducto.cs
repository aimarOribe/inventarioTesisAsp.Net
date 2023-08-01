using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class cnProducto
    {
        private cdProducto ocdProducto = new cdProducto();

        public List<Producto> ListarProductos()
        {
            return ocdProducto.ListarProductos();
        }

        public int RegistrarProducto(Producto producto, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (producto.CODIGO == "")
            {
                Mensaje += "Es necesario ingresar el codigo del producto\n";
            }

            if (producto.NOMBRE == "")
            {
                Mensaje += "Es necesario ingresar el nombre del producto\n";
            }

            if (producto.DESCRIPCION == "")
            {
                Mensaje += "Es necesario ingresar la descripcion del productoo\n";
            }

            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return ocdProducto.RegistrarProducto(producto, out Mensaje);
            }
        }

        public bool EditarProducto(Producto producto, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (producto.CODIGO == "")
            {
                Mensaje += "Es necesario ingresar el codigo del producto\n";
            }

            if (producto.NOMBRE == "")
            {
                Mensaje += "Es necesario ingresar el nombre del producto\n";
            }

            if (producto.DESCRIPCION == "")
            {
                Mensaje += "Es necesario ingresar la descripcion del productoo\n";
            }

            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return ocdProducto.EditarProducto(producto, out Mensaje);
            }
        }

        public bool EliminarProducto(Producto producto, out string Mensaje)
        {
            return ocdProducto.EliminarProducto(producto, out Mensaje);
        }
    }
}
