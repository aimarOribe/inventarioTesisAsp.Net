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
    public partial class frmCategorias : Form
    {
        public frmCategorias()
        {
            InitializeComponent();
        }

        private void cargarMedidas()
        {
            cboEstado.Items.Add(new OpcionCombo { Texto = "Activo", Valor = 1 });
            cboEstado.Items.Add(new OpcionCombo { Texto = "No Activo", Valor = 0 });
            cboEstado.DisplayMember = "Texto";
            cboEstado.ValueMember = "Value";
            cboEstado.SelectedIndex = 0;

            List<Medida> listaMedidas = new cnMedida().ListarMedidas();
            foreach (Medida item in listaMedidas)
            {
                cboMedida.Items.Add(new OpcionCombo { Texto = item.DESCRIPCION, Valor = item.IDMEDIDA });
            }
            cboMedida.DisplayMember = "Texto";
            cboMedida.ValueMember = "Value";
            cboMedida.SelectedIndex = 0;
        }

        private void cargarBusquedaColumnasTablaCategorias()
        {
            foreach (DataGridViewColumn columna in dgvCategorias.Columns)
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

        private void cargarUsuariosEnTablaCategorias()
        {
            List<Categoria> listaCategorias = new cnCategoria().ListarCategorias();
            foreach (Categoria item in listaCategorias)
            {
                dgvCategorias.Rows.Add(new object[] { "", item.IDCATEGORIA ,item.DESCRIPCION,
                    item.oMEDIDA.IDMEDIDA,
                    item.oMEDIDA.DESCRIPCION,
                    item.ESTADO == true ? 1 : 0,
                    item.ESTADO == true ? "Activo" : "No Activo"
                });
            }
        }

        private void limpiar()
        {
            txtIndice.Text = "-1";
            txtId.Text = "0";
            txtDescripcion.Text = "";
            cboMedida.SelectedIndex = 0;
            cboEstado.SelectedIndex = 0;
            txtDescripcion.Select();
        }

        private void frmCategorias_Load(object sender, EventArgs e)
        {
            cargarMedidas();
            cargarBusquedaColumnasTablaCategorias();
            cargarUsuariosEnTablaCategorias();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            Categoria categoria = new Categoria
            {
                IDCATEGORIA = Convert.ToInt32(txtId.Text),
                DESCRIPCION = txtDescripcion.Text,
                oMEDIDA = new Medida { IDMEDIDA = Convert.ToInt32(((OpcionCombo)cboMedida.SelectedItem).Valor) },
                ESTADO = Convert.ToInt32(((OpcionCombo)cboEstado.SelectedItem).Valor) == 1 ? true : false
            };

            if (categoria.IDCATEGORIA == 0)
            {
                int idCategoriaGenerada = new cnCategoria().RegistrarCategoria(categoria, out mensaje);

                if (idCategoriaGenerada != 0)
                {
                    dgvCategorias.Rows.Add(new object[] { "", idCategoriaGenerada, txtDescripcion.Text,
                    ((OpcionCombo)cboMedida.SelectedItem).Valor.ToString(),
                    ((OpcionCombo)cboMedida.SelectedItem).Texto.ToString(),
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
                bool resultado = new cnCategoria().EditarCategoria(categoria, out mensaje);
                if (resultado)
                {
                    DataGridViewRow row = dgvCategorias.Rows[Convert.ToInt32(txtIndice.Text)];
                    row.Cells["Id"].Value = txtId.Text;
                    row.Cells["Descripcion"].Value = txtDescripcion.Text;
                    row.Cells["IdMedida"].Value = ((OpcionCombo)cboMedida.SelectedItem).Valor.ToString();
                    row.Cells["Medida"].Value = ((OpcionCombo)cboMedida.SelectedItem).Texto.ToString();
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

        private void dgvCategorias_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void dgvCategorias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCategorias.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    txtIndice.Text = indice.ToString();
                    txtId.Text = dgvCategorias.Rows[indice].Cells["Id"].Value.ToString();
                    txtDescripcion.Text = dgvCategorias.Rows[indice].Cells["Descripcion"].Value.ToString();
                    foreach (OpcionCombo oc in cboMedida.Items)
                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvCategorias.Rows[indice].Cells["IdMedida"].Value.ToString()))
                        {
                            int indiceCombo = cboMedida.Items.IndexOf(oc);
                            cboMedida.SelectedIndex = indiceCombo;
                            break;
                        }
                    }
                    foreach (OpcionCombo oc in cboEstado.Items)
                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvCategorias.Rows[indice].Cells["EstadoValor"].Value.ToString()))
                        {
                            int indiceCombo = cboEstado.Items.IndexOf(oc);
                            cboEstado.SelectedIndex = indiceCombo;
                            break;
                        }
                    }
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
                if (MessageBox.Show("¿Desea eliminar la categoria?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string mensaje = string.Empty;
                    Categoria categoria = new Categoria { IDCATEGORIA = Convert.ToInt32(txtId.Text) };
                    bool respuesta = new cnCategoria().EliminarCategoria(categoria, out mensaje);
                    if (respuesta)
                    {
                        dgvCategorias.Rows.RemoveAt(Convert.ToInt32(txtIndice.Text));
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
            if (dgvCategorias.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvCategorias.Rows)
                {
                    if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txtBusqueda.Text.Trim().ToUpper()))
                        row.Visible = true;
                    else
                        row.Visible = false;
                }
            }
        }

        private void btnLimpiarBusqueda_Click(object sender, EventArgs e)
        {
            txtBusqueda.Text = "";
            foreach (DataGridViewRow row in dgvCategorias.Rows)
            {
                row.Visible = true;
            }
        }

        private void btnCerrarModalCategorias_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
