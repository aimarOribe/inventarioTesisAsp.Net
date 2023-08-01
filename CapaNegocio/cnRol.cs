using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class cnRol
    {
        private cdRol ocdRol = new cdRol();

        public List<Rol> ListarRoles()
        {
            return ocdRol.ListarRoles();
        }
    }
}
