using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using CapaEntidad;

namespace CapaPresentacion
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new cnUsuario().ListarUsuarios().Where(u => u.DOCUMENTO == txtDocumento.Text && u.CLAVE == txtClave.Text).FirstOrDefault();

            if (usuario != null)
            {
                //Inicio formInicio = new Inicio(usuario);
                frmPrincipal frmPrincipal = new frmPrincipal(usuario);

                //formInicio.Show();
                frmPrincipal.Show();
                
                //this.Hide();
                this.Hide();

                //formInicio.FormClosing += frm_closing;
                frmPrincipal.FormClosing += frm_closing;
            }
            else
            {
                MessageBox.Show("La informacion ingresada es incorrecta", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            
        }

        private void frm_closing(object sender, FormClosingEventArgs e)
        {
            txtDocumento.Text = "";
            txtClave.Text = "";
            this.Show();
        }
    }
}
