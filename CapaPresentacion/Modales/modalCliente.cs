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
    public partial class modalCliente : Form
    {
        public Cliente cliente { get; set; }
        public modalCliente()
        {
            InitializeComponent();
        }

        private void cargarBusquedaColumnasTablaModalClientes()
        {
            foreach (DataGridViewColumn columna in dgvModalCliente.Columns)
            {
                cboBusqueda.Items.Add(new OpcionCombo { Texto = columna.HeaderText, Valor = columna.Name });
            }
            cboBusqueda.DisplayMember = "Texto";
            cboBusqueda.ValueMember = "Value";
            cboBusqueda.SelectedIndex = 0;
        }

        private void cargarUsuariosEnTablaModalClientes()
        {
            List<Cliente> listaClientes = new cnCliente().ListarClientes();
            foreach (Cliente item in listaClientes)
            {
                if (item.ESTADO)
                {
                    dgvModalCliente.Rows.Add(new object[] { item.DOCUMENTO, item.NOMBRECOMPLETO });
                }
            }
        }

        private void modalCliente_Load(object sender, EventArgs e)
        {
            cargarBusquedaColumnasTablaModalClientes();
            cargarUsuariosEnTablaModalClientes();
        }

        private void dgvModalCliente_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int indicefilaSeleccionada = e.RowIndex;
            int indiceColumnaSeleccionada = e.ColumnIndex;
            if (indicefilaSeleccionada >= 0 && indiceColumnaSeleccionada > 0)
            {
                cliente = new Cliente
                {
                    DOCUMENTO = dgvModalCliente.Rows[indicefilaSeleccionada].Cells["Documento"].Value.ToString(),
                    NOMBRECOMPLETO = dgvModalCliente.Rows[indicefilaSeleccionada].Cells["NombreCompleto"].Value.ToString()
                };
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string columnaFiltro = ((OpcionCombo)cboBusqueda.SelectedItem).Valor.ToString();
            if (dgvModalCliente.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvModalCliente.Rows)
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
            foreach (DataGridViewRow row in dgvModalCliente.Rows)
            {
                row.Visible = true;
            }
        }
    }
}
