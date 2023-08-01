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
    public partial class frmProveedores : Form
    {
        public frmProveedores()
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
            foreach (DataGridViewColumn columna in dgvProveedores.Columns)
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
            List<Proveedor> listaProveedores = new cnProveedor().ListarProveedor();
            foreach (Proveedor item in listaProveedores)
            {
                dgvProveedores.Rows.Add(new object[] { "", item.IDPROVEEDOR, item.DOCUMENTO, item.RAZONSOCIAL, item.CORREO, item.TELEFONO,
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
            txtRazonSocial.Text = "";
            txtCorreo.Text = "";
            txtTelefono.Text = "";
            cboEstado.SelectedIndex = 0;
            txtDocumento.Select();
        }

        private void frmProveedores_Load(object sender, EventArgs e)
        {
            cargarEstado();
            cargarBusquedaColumnasTablaClientes();
            cargarUsuariosEnTablaClientes();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            Proveedor proveedor = new Proveedor
            {
                IDPROVEEDOR = Convert.ToInt32(txtId.Text),
                DOCUMENTO = txtDocumento.Text,
                RAZONSOCIAL = txtRazonSocial.Text,
                CORREO = txtCorreo.Text,
                TELEFONO = txtTelefono.Text,
                ESTADO = Convert.ToInt32(((OpcionCombo)cboEstado.SelectedItem).Valor) == 1 ? true : false
            };

            if (proveedor.IDPROVEEDOR == 0)
            {
                int idProveedorGenerado = new cnProveedor().RegistrarProveedor(proveedor, out mensaje);

                if (idProveedorGenerado != 0)
                {
                    dgvProveedores.Rows.Add(new object[] { "", idProveedorGenerado, txtDocumento.Text, txtRazonSocial.Text, txtCorreo.Text, txtTelefono.Text,
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
                bool resultado = new cnProveedor().EditarProveedor(proveedor, out mensaje);
                if (resultado)
                {
                    DataGridViewRow row = dgvProveedores.Rows[Convert.ToInt32(txtIndice.Text)];
                    row.Cells["Id"].Value = txtId.Text;
                    row.Cells["Documento"].Value = txtDocumento.Text;
                    row.Cells["RazonSocial"].Value = txtRazonSocial.Text;
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
                    Proveedor proveedor = new Proveedor { IDPROVEEDOR = Convert.ToInt32(txtId.Text) };
                    bool respuesta = new cnProveedor().EliminarProveedor(proveedor, out mensaje);
                    if (respuesta)
                    {
                        dgvProveedores.Rows.RemoveAt(Convert.ToInt32(txtIndice.Text));
                        limpiar();
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Problema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string columnaFiltro = ((OpcionCombo)cboBusqueda.SelectedItem).Valor.ToString();
            if (dgvProveedores.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvProveedores.Rows)
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
            foreach (DataGridViewRow row in dgvProveedores.Rows)
            {
                row.Visible = true;
            }
        }

        private void dgvProveedores_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void dgvProveedores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProveedores.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    txtIndice.Text = indice.ToString();
                    txtId.Text = dgvProveedores.Rows[indice].Cells["Id"].Value.ToString();
                    txtDocumento.Text = dgvProveedores.Rows[indice].Cells["Documento"].Value.ToString();
                    txtRazonSocial.Text = dgvProveedores.Rows[indice].Cells["RazonSocial"].Value.ToString();
                    txtCorreo.Text = dgvProveedores.Rows[indice].Cells["Correo"].Value.ToString();
                    txtTelefono.Text = dgvProveedores.Rows[indice].Cells["Telefono"].Value.ToString();
                    foreach (OpcionCombo oc in cboEstado.Items)
                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvProveedores.Rows[indice].Cells["EstadoValor"].Value.ToString()))
                        {
                            int indiceCombo = cboEstado.Items.IndexOf(oc);
                            cboEstado.SelectedIndex = indiceCombo;
                            break;
                        }
                    }
                }
            }
        }

        private void btnCerrarProveedores_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
