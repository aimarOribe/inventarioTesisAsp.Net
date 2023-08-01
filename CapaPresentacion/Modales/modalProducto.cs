using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utilidades;
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
    public partial class modalProducto : Form
    {
        public Producto producto { get; set; }
        public Medida medida { get; set; }
        public modalProducto()
        {
            InitializeComponent();
        }

        private void cargarBusquedaColumnasTablaModalProductos()
        {
            foreach (DataGridViewColumn columna in dgvModalProductos.Columns)
            {
                if (columna.Visible == true)
                {
                    cboBusqueda.Items.Add(new OpcionCombo { Texto = columna.HeaderText, Valor = columna.Name });
                }
            }
            cboBusqueda.DisplayMember = "Texto";
            cboBusqueda.ValueMember = "Value";
            cboBusqueda.SelectedIndex = 0;
        }

        private void cargarUsuariosEnTablaModalProductos()
        {
            List<Producto> listaProductos = new cnProducto().ListarProductos();
            foreach (Producto item in listaProductos)
            {
                if (item.ESTADO)
                {
                    dgvModalProductos.Rows.Add(new object[] { item.IDPRODUCTO, item.CODIGO, item.NOMBRE, item.oCATEGORIA.DESCRIPCION, item.STOCK, item.PRECIOCOMPRA, item.PRECIOVENTA, item.oCATEGORIA.oMEDIDA.DESCRIPCION });
                }
            }
        }

        private void modalProducto_Load(object sender, EventArgs e)
        {
            cargarBusquedaColumnasTablaModalProductos();
            cargarUsuariosEnTablaModalProductos();
        }

        private void dgvModalProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int indicefilaSeleccionada = e.RowIndex;
            int indiceColumnaSeleccionada = e.ColumnIndex;
            if (indicefilaSeleccionada >= 0 && indiceColumnaSeleccionada > 0)
            {
                producto = new Producto
                {
                    IDPRODUCTO = Convert.ToInt32(dgvModalProductos.Rows[indicefilaSeleccionada].Cells["Id"].Value.ToString()),
                    CODIGO = dgvModalProductos.Rows[indicefilaSeleccionada].Cells["Codigo"].Value.ToString(),
                    NOMBRE = dgvModalProductos.Rows[indicefilaSeleccionada].Cells["Nombre"].Value.ToString(),
                    STOCK = Convert.ToInt32(dgvModalProductos.Rows[indicefilaSeleccionada].Cells["Stock"].Value.ToString()),
                    PRECIOCOMPRA = Convert.ToDecimal(dgvModalProductos.Rows[indicefilaSeleccionada].Cells["PrecioCompra"].Value.ToString()),
                    PRECIOVENTA = Convert.ToDecimal(dgvModalProductos.Rows[indicefilaSeleccionada].Cells["PrecioVenta"].Value.ToString()),
                };
                medida = new Medida
                {
                    DESCRIPCION = dgvModalProductos.Rows[indicefilaSeleccionada].Cells["Medida"].Value.ToString()
                };
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string columnaFiltro = ((OpcionCombo)cboBusqueda.SelectedItem).Valor.ToString();
            if (dgvModalProductos.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvModalProductos.Rows)
                {
                    if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txtBusqueda.Text.Trim().ToUpper()))
                        row.Visible = true;
                    else
                        row.Visible = false;

                }
            }
        }

        private void btnLimpiarBuscador_Click(object sender, EventArgs e)
        {
            txtBusqueda.Text = "";
            foreach (DataGridViewRow row in dgvModalProductos.Rows)
            {
                row.Visible = true;
            }
        }
    }
}
