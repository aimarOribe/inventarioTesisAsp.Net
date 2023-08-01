using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Modales;
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

namespace CapaPresentacion
{
    public partial class frmPrincipal : Form
    {
        private static Usuario usuarioActual;
        private static Form formularioActivo = null;
        List<IconButton> listaBotones = new List<IconButton>();
        public frmPrincipal(Usuario usuario = null)
        {
            if (usuario == null)
            {
                usuarioActual = new Usuario
                {
                    NOMBRECOMPLETO = "AdminPredefinido",
                    IDUSUARIO = 1
                };
            }
            else
            {
                usuarioActual = usuario;
            }
            InitializeComponent();
        }

        private void cargarBotonesPermisos()
        {
            listaBotones = new List<IconButton>();
            listaBotones.Add(menuVenta);
            listaBotones.Add(menuCompra);
            listaBotones.Add(menuMantenedor);
            listaBotones.Add(menuCliente);
            listaBotones.Add(menuProveedor);
            listaBotones.Add(menuReporte);
            listaBotones.Add(menuConfiguraciones);
            listaBotones.Add(menuAcercaDe);
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

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            cargarBotonesPermisos();
            List<Permiso> ListaPermisos = new cnPermiso().ListarPermisos(usuarioActual.IDUSUARIO);
            foreach (IconButton boton in listaBotones)
            {
                bool encontrado = ListaPermisos.Any(b => b.NOMBREMENU == boton.Name);
                if (encontrado == false)
                {
                    boton.Visible = false;
                }
            }
            lblUsuario.Text = usuarioActual.NOMBRECOMPLETO.ToString();
            lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt");
        }

        private void menuVenta_Click(object sender, EventArgs e)
        {
            abrirFormulario(new modalVentas(usuarioActual));
        }

        private void menuCompra_Click(object sender, EventArgs e)
        {
            abrirFormulario(new modalCompras(usuarioActual));
        }

        private void menuCliente_Click(object sender, EventArgs e)
        {
            abrirFormulario(new frmClientes());
        }

        private void frm_closing(object sender, FormClosingEventArgs e)
        {
            this.Show();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuAcercaDe_Click(object sender, EventArgs e)
        {
            abrirFormulario(new modalAcercaDe());
        }

        private void menuConfiguraciones_Click(object sender, EventArgs e)
        {
            abrirFormulario(new modalConfiguraciones());
        }

        private void menuMantenedor_Click(object sender, EventArgs e)
        {
            abrirFormulario(new modalMantenedor());
        }

        private void menuProveedor_Click(object sender, EventArgs e)
        {
            abrirFormulario(new frmProveedores());
        }

        private void menuReporte_Click(object sender, EventArgs e)
        {
            abrirFormulario(new modalReportes());
        }
    }
}
