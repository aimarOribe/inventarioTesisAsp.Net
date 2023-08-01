using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class cnPermiso
    {
        private cdPermiso ocdPermiso = new cdPermiso();

        public List<Permiso> ListarPermisos(int idUsuario)
        {
            return ocdPermiso.ListarPermisos(idUsuario);
        }

        public List<Permiso> ListarPermisosAdministrador()
        {
            return ocdPermiso.ListarPermisosAdministrador();
        }

        public List<Permiso> ListarPermisosEmpleado()
        {
            return ocdPermiso.ListarPermisosEmpleado();
        }

        public int RegistrarPermiso(Permiso permiso)
        {
            return ocdPermiso.RegistrarPermiso(permiso);
        }

        public int EliminarPermiso(Permiso permiso)
        {
            return ocdPermiso.EliminarPermiso(permiso);
        }
    }
}
