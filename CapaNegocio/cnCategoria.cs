using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class cnCategoria
    {
        private cdCategoria ocdCategoria = new cdCategoria();

        public List<Categoria> ListarCategorias()
        {
            return ocdCategoria.ListarCategorias();
        }

        public int RegistrarCategoria(Categoria categoria, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (categoria.DESCRIPCION == "" || categoria.DESCRIPCION.Length < 3)
            {
                Mensaje += "Es necesario la descripcion de la categoria y esta debe tener mas de 3 caracteres\n";
            }


            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return ocdCategoria.RegistrarCategoria(categoria, out Mensaje);
            }
        }

        public bool EditarCategoria(Categoria categoria, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (categoria.DESCRIPCION == "" || categoria.DESCRIPCION.Length < 3)
            {
                Mensaje += "Es necesario la descripcion de la categoria y esta debe tener mas de 3 caracteres\n";
            }

            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return ocdCategoria.EditarCategoria(categoria, out Mensaje);
            }
        }

        public bool EliminarCategoria(Categoria categoria, out string Mensaje)
        {
            return ocdCategoria.EliminarCategoria(categoria, out Mensaje);
        }
    }
}
