using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Modales
{
    public partial class modalPermiso : Form
    {
        public modalPermiso()
        {
            InitializeComponent();
        }

        private void modalPermiso_Load(object sender, EventArgs e)
        {
            List<Permiso> listaPermisosAdministrador = new cnPermiso().ListarPermisosAdministrador();
            List<Permiso> listaPermisosEmpleado = new cnPermiso().ListarPermisosEmpleado();
            List<string> listaPermisos = new List<string>
            {
                "menuUsuario",
                "menuMantenedor",
                "menuVenta",
                "menuCompra",
                "menuProveedor",
                "menuCliente",
                "menuReporte",
                "menuConfiguraciones",
                "menuAcercaDe"
            };
            foreach (string item in listaPermisos)
            {
                bool encontradoAdministrador = listaPermisosAdministrador.Any(pa => pa.NOMBREMENU == item);
                if (encontradoAdministrador)
                {
                    clbPermisosAdministrador.Items.Add(item, true);
                }
                else
                {
                    clbPermisosAdministrador.Items.Add(item);

                }

                bool encontradoEmpleado = listaPermisosEmpleado.Any(pe => pe.NOMBREMENU == item);
                if (encontradoEmpleado)
                {
                    clbPermisosEmpleados.Items.Add(item, true);
                }
                else
                {
                    clbPermisosEmpleados.Items.Add(item);

                }
            }
        }

        private void btnGuardarCambiosPermisosAdministrador_Click(object sender, EventArgs e)
        {
            int resultado = 0;
            Permiso permiso = new Permiso
            {
                oROL = new Rol { IDROL = 1 }
            };

            for (int i = 0; i <= (clbPermisosAdministrador.Items.Count - 1); i++)
            {
                if (clbPermisosAdministrador.GetItemChecked(i))
                {
                    permiso.NOMBREMENU = clbPermisosAdministrador.Items[i].ToString();
                    resultado = new cnPermiso().RegistrarPermiso(permiso);
                }
                else
                {
                    permiso.NOMBREMENU = clbPermisosAdministrador.Items[i].ToString();
                    resultado = new cnPermiso().EliminarPermiso(permiso);
                }
            }

            if (resultado != 0)
            {
                MessageBox.Show("Permisos Guardados Correctamente");
            }
        }

        private void btnGuardarCambiosPermisosEmpleado_Click(object sender, EventArgs e)
        {
            int resultado = 0;
            Permiso permiso = new Permiso
            {
                oROL = new Rol { IDROL = 2 }
            };

            for (int i = 0; i <= (clbPermisosEmpleados.Items.Count - 1); i++)
            {
                if (clbPermisosEmpleados.GetItemChecked(i))
                {
                    permiso.NOMBREMENU = clbPermisosEmpleados.Items[i].ToString();
                    resultado = new cnPermiso().RegistrarPermiso(permiso);
                }
                else
                {
                    permiso.NOMBREMENU = clbPermisosEmpleados.Items[i].ToString();
                    resultado = new cnPermiso().EliminarPermiso(permiso);
                }
            }
            if(resultado != 0)
            {
                MessageBox.Show("Permisos Guardados Correctamente");
            }
        }

        private void btnCerrarModalPermisos_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
