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
    public partial class modalProveedor : Form
    {
        public Proveedor proveedor {get; set;}
        public modalProveedor()
        {
            InitializeComponent();
        }

        private void cargarBusquedaColumnasTablaModalProveedores()
        {
            foreach (DataGridViewColumn columna in dgvModalProveedores.Columns)
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

        private void cargarUsuariosEnTablaModalProveedores()
        {
            List<Proveedor> listaProveedores = new cnProveedor().ListarProveedor();
            foreach (Proveedor item in listaProveedores)
            {
                if (item.ESTADO)
                {
                    dgvModalProveedores.Rows.Add(new object[] {item.IDPROVEEDOR, item.DOCUMENTO, item.RAZONSOCIAL});
                }
            }
        }

        private void modalProveedor_Load(object sender, EventArgs e)
        {
            cargarBusquedaColumnasTablaModalProveedores();
            cargarUsuariosEnTablaModalProveedores();
        }

        private void dgvModalProveedores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int indicefilaSeleccionada = e.RowIndex;
            int indiceColumnaSeleccionada = e.ColumnIndex;
            if (indicefilaSeleccionada >= 0 && indiceColumnaSeleccionada > 0)
            {
                proveedor = new Proveedor
                {
                    IDPROVEEDOR = Convert.ToInt32(dgvModalProveedores.Rows[indicefilaSeleccionada].Cells["Id"].Value.ToString()),
                    DOCUMENTO = dgvModalProveedores.Rows[indicefilaSeleccionada].Cells["Documento"].Value.ToString(),
                    RAZONSOCIAL = dgvModalProveedores.Rows[indicefilaSeleccionada].Cells["RazonSocial"].Value.ToString()
                };
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string columnaFiltro = ((OpcionCombo)cboBusqueda.SelectedItem).Valor.ToString();
            if (dgvModalProveedores.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvModalProveedores.Rows)
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
            foreach (DataGridViewRow row in dgvModalProveedores.Rows)
            {
                row.Visible = true;
            }
        }
    }
}
