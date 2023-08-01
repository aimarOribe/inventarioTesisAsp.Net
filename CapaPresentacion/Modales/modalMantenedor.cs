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
    public partial class modalMantenedor : Form
    {
        private static Form formularioActivo = null;
        public modalMantenedor()
        {
            InitializeComponent();
        }

        private void modalMantenedor_Load(object sender, EventArgs e)
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

        private void btnModalCategorias_Click(object sender, EventArgs e)
        {
            abrirFormulario(new frmCategorias());
        }

        private void btnModalProductos_Click(object sender, EventArgs e)
        {
            abrirFormulario(new frmProductos());
        }

        private void btnCerrarModalConfiguraciones_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
