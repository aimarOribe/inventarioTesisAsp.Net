using CapaEntidad;
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
    public partial class modalVentas : Form
    {
        private static Usuario usuarioActual;
        private static Form formularioActivo = null;
        public modalVentas(Usuario usuario = null)
        {
            usuarioActual = usuario;
            InitializeComponent();
        }

        private void modalVentas_Load(object sender, EventArgs e)
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

        private void btnModalRegistrarVentas_Click(object sender, EventArgs e)
        {
            abrirFormulario(new frmVentas(usuarioActual));
        }

        private void btnModalVerDetallesVentas_Click(object sender, EventArgs e)
        {
            abrirFormulario(new frmDetalleVenta());
        }

        private void frm_closing(object sender, FormClosingEventArgs e)
        {
            this.Show();
        }

        private void btnCerrarModalVentas_Click(object sender, EventArgs e)
        {
            this.Close();
        }   
    }
}
