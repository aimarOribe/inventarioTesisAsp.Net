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

namespace CapaPresentacion
{
    public partial class frmClientes : Form
    {
        public frmClientes()
        {
            InitializeComponent();
        }

        private void cargarEstado()
        {
            cboEstado.Items.Add(new OpcionCombo { Texto = "Activo", Valor = 1 });
            cboEstado.Items.Add(new OpcionCombo { Texto = "No Activo", Valor = 0 });
            cboEstado.DisplayMember = "Texto";
            cboEstado.ValueMember = "Value";
            cboEstado.SelectedIndex = 0;
        }

        private void cargarBusquedaColumnasTablaClientes()
        {
            foreach (DataGridViewColumn columna in dgvClientes.Columns)
            {
                if (columna.Visible == true && columna.Name != "btnSeleccionar")
                {
                    cboBusqueda.Items.Add(new OpcionCombo { Texto = columna.HeaderText, Valor = columna.Name });
                }
            }
            cboBusqueda.DisplayMember = "Texto";
            cboBusqueda.ValueMember = "Value";
            cboBusqueda.SelectedIndex = 0;
        }

        private void cargarUsuariosEnTablaClientes()
        {
            List<Cliente> listaClientes = new cnCliente().ListarClientes();
            foreach (Cliente item in listaClientes)
            {
                dgvClientes.Rows.Add(new object[] { "", item.IDCLIENTE, item.DOCUMENTO, item.NOMBRECOMPLETO, item.CORREO, item.TELEFONO,
                    item.ESTADO == true ? 1 : 0,
                    item.ESTADO == true ? "Activo" : "No Activo"
                });
            }
        }

        private void limpiar()
        {
            txtIndice.Text = "-1";
            txtId.Text = "0";
            txtDocumento.Text = "";
            txtNombreCompleto.Text = "";
            txtCorreo.Text = "";
            txtTelefono.Text = "";
            cboEstado.SelectedIndex = 0;
            txtDocumento.Select();
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            cargarEstado();
            cargarBusquedaColumnasTablaClientes();
            cargarUsuariosEnTablaClientes();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            Cliente cliente = new Cliente
            {
                IDCLIENTE = Convert.ToInt32(txtId.Text),
                DOCUMENTO = txtDocumento.Text,
                NOMBRECOMPLETO = txtNombreCompleto.Text,
                CORREO = txtCorreo.Text,
                TELEFONO = txtTelefono.Text,
                ESTADO = Convert.ToInt32(((OpcionCombo)cboEstado.SelectedItem).Valor) == 1 ? true : false
            };

            if (cliente.IDCLIENTE == 0)
            {
                int idClienteGenerado = new cnCliente().RegistrarCLiente(cliente, out mensaje);

                if (idClienteGenerado != 0)
                {
                    dgvClientes.Rows.Add(new object[] { "", idClienteGenerado, txtDocumento.Text, txtNombreCompleto.Text, txtCorreo.Text, txtTelefono.Text,
                    ((OpcionCombo)cboEstado.SelectedItem).Valor.ToString(),
                    ((OpcionCombo)cboEstado.SelectedItem).Texto.ToString()
                    });
                    limpiar();
                }
                else
                {
                    MessageBox.Show(mensaje);
                }
            }
            else
            {
                bool resultado = new cnCliente().EditarCliente(cliente, out mensaje);
                if (resultado)
                {
                    DataGridViewRow row = dgvClientes.Rows[Convert.ToInt32(txtIndice.Text)];
                    row.Cells["Id"].Value = txtId.Text;
                    row.Cells["Documento"].Value = txtDocumento.Text;
                    row.Cells["NombreCompleto"].Value = txtNombreCompleto.Text;
                    row.Cells["Correo"].Value = txtCorreo.Text;
                    row.Cells["Telefono"].Value = txtTelefono.Text;
                    row.Cells["EstadoValor"].Value = ((OpcionCombo)cboEstado.SelectedItem).Valor.ToString();
                    row.Cells["Estado"].Value = ((OpcionCombo)cboEstado.SelectedItem).Texto.ToString();
                    limpiar();
                }
                else
                {
                    MessageBox.Show(mensaje);
                }
            }
            
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtId.Text) != 0)
            {
                if (MessageBox.Show("¿Desea eliminar al cliente?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string mensaje = string.Empty;
                    Cliente cliente = new Cliente { IDCLIENTE = Convert.ToInt32(txtId.Text) };
                    bool respuesta = new cnCliente().EliminarCliente(cliente, out mensaje);
                    if (respuesta)
                    {
                        dgvClientes.Rows.RemoveAt(Convert.ToInt32(txtIndice.Text));
                        limpiar();
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Problema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                }
            }
        }

        private void dgvClientes_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            if (e.ColumnIndex == 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var w = Properties.Resources.check.Width;
                var h = Properties.Resources.check.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;
                e.Graphics.DrawImage(Properties.Resources.check, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvClientes.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    txtIndice.Text = indice.ToString();
                    txtId.Text = dgvClientes.Rows[indice].Cells["Id"].Value.ToString();
                    txtDocumento.Text = dgvClientes.Rows[indice].Cells["Documento"].Value.ToString();
                    txtNombreCompleto.Text = dgvClientes.Rows[indice].Cells["NombreCompleto"].Value.ToString();
                    txtCorreo.Text = dgvClientes.Rows[indice].Cells["Correo"].Value.ToString();
                    txtTelefono.Text = dgvClientes.Rows[indice].Cells["Telefono"].Value.ToString();
                    foreach (OpcionCombo oc in cboEstado.Items)
                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvClientes.Rows[indice].Cells["EstadoValor"].Value.ToString()))
                        {
                            int indiceCombo = cboEstado.Items.IndexOf(oc);
                            cboEstado.SelectedIndex = indiceCombo;
                            break;
                        }
                    }
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string columnaFiltro = ((OpcionCombo)cboBusqueda.SelectedItem).Valor.ToString();
            if (dgvClientes.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvClientes.Rows)
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
            foreach (DataGridViewRow row in dgvClientes.Rows)
            {
                row.Visible = true;
            }
        }

        private void btnCerrarFormularioClientes_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
