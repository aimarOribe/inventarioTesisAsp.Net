using FontAwesome.Sharp;
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
    public partial class modalConfiguraciones : Form
    {
        private static Form formularioActivo = null;

        public modalConfiguraciones()
        {
            InitializeComponent();
        }

        private void modalConfiguraciones_Load(object sender, EventArgs e)
        {

        }

        private void abrirFormulario(Form form)
        {
            if (formularioActivo != null)
            {
                formularioActivo.Close();
            }
            formularioActivo = form;
            form.BackColor = Color.LightSteelBlue;
            form.Show();
            this.Hide();
            form.FormClosing += frm_closing;
        }

        private void frm_closing(object sender, FormClosingEventArgs e)
        {
            this.Show();
        }

        private void btnModalNegocio_Click(object sender, EventArgs e)
        {
            abrirFormulario(new frmNegocio());
        }

        private void btnModalUsuarios_Click(object sender, EventArgs e)
        {
            abrirFormulario(new frmUsuarios());
        }

        private void btnModalPermisos_Click(object sender, EventArgs e)
        {
            abrirFormulario(new modalPermiso());
        }

        private void btnCerrarModalConfiguraciones_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
