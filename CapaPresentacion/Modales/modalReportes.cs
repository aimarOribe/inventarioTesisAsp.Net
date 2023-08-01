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
    public partial class modalReportes : Form
    {
        private static Form formularioActivo = null;
        public modalReportes()
        {
            InitializeComponent();
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

        private void btnModalReporteVentas_Click(object sender, EventArgs e)
        {
            abrirFormulario(new frmReporteVentas());
        }

        private void btnModalReporteCompras_Click(object sender, EventArgs e)
        {
            abrirFormulario(new frmReporteCompras());
        }

        private void frm_closing(object sender, FormClosingEventArgs e)
        {
            this.Show();
        }

        private void btnCerrarModalReportes_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
