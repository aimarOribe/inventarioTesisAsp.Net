using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad;
using FontAwesome.Sharp;
using CapaNegocio;
using CapaPresentacion.Modales;

namespace CapaPresentacion
{
    public partial class Inicio : Form
    {
        private static Usuario usuarioActual;
        private static IconMenuItem menuActivo = null;
        private static Form formularioActivo = null;
        public Inicio(Usuario usuario = null)
        {
            if(usuario == null)
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

        private void abrirFormulario(IconMenuItem menu, Form form)
        {
            if(menuActivo != null)
            {
                menuActivo.BackColor = Color.White;
            }
            menu.BackColor = Color.Silver;
            menuActivo = menu;

            if(formularioActivo != null)
            {
                formularioActivo.Close();
            }
            formularioActivo = form;
            form.TopLevel = false;
            form.FormBorderStyle= FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            form.BackColor = Color.LightSteelBlue;
            contenedor.Controls.Add(form);
            form.Show();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            List<Permiso> ListaPermisos = new cnPermiso().ListarPermisos(usuarioActual.IDUSUARIO);
            foreach (IconMenuItem iconMenu in menu.Items)
            {
                bool encontrado = ListaPermisos.Any(m => m.NOMBREMENU == iconMenu.Name);
                if (encontrado == false)
                {
                    iconMenu.Visible = false;
                }
            }
            lblUsuario.Text = usuarioActual.NOMBRECOMPLETO.ToString();
            lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt");
        }

        private void subMenuCategoria_Click(object sender, EventArgs e)
        {
            abrirFormulario(menuMantenedor, new frmCategorias());
        }

        private void subMenuProductos_Click(object sender, EventArgs e)
        {
            abrirFormulario(menuMantenedor, new frmProductos());
        }

        private void registraVentaSubMenu_Click(object sender, EventArgs e)
        {
            abrirFormulario(menuVenta, new frmVentas(usuarioActual));
        }

        private void detalleVentaSubMenu_Click(object sender, EventArgs e)
        {
            abrirFormulario(menuVenta, new frmDetalleVenta());
        }

        private void menuCliente_Click(object sender, EventArgs e)
        {
            abrirFormulario((IconMenuItem)sender, new frmClientes());
        }

        private void registrarCompraSubMenu_Click(object sender, EventArgs e)
        {
            abrirFormulario(menuCompra, new frmCompras(usuarioActual));
        }

        private void detalleCompraSubMenu_Click(object sender, EventArgs e)
        {
            abrirFormulario(menuCompra, new frmDetalleCompra());
        }

        private void menuProveedor_Click(object sender, EventArgs e)
        {
            abrirFormulario((IconMenuItem)sender, new frmProveedores());
        }

        private void subMenuReporteCompras_Click(object sender, EventArgs e)
        {
            abrirFormulario(menuReporte, new frmReporteCompras());
        }

        private void subMenuReporteVentas_Click(object sender, EventArgs e)
        {
            abrirFormulario(menuReporte, new frmReporteVentas());

        }

        private void subMenuNegocio_Click_1(object sender, EventArgs e)
        {
            abrirFormulario(menuMantenedor, new frmNegocio());
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea salir del Sistema?","Mensaje",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void permisosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            modalPermiso permiso = new modalPermiso();
            permiso.ShowDialog();
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            modalAcercaDe acercaDe = new modalAcercaDe();
            acercaDe.ShowDialog();
        }

        private void subMenuUsuarios_Click(object sender, EventArgs e)
        {
            abrirFormulario(menuConfiguraciones, new frmUsuarios());
        }

        private void contenedor_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
