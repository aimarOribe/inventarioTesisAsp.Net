using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace CapaPresentacion
{
    public partial class frmProductos : Form
    {
        public frmProductos()
        {
            InitializeComponent();
        }

        private void cargarEstadoYCategorias()
        {
            cboEstado.Items.Add(new OpcionCombo { Texto = "Activo", Valor = 1 });
            cboEstado.Items.Add(new OpcionCombo { Texto = "No Activo", Valor = 0 });
            cboEstado.DisplayMember = "Texto";
            cboEstado.ValueMember = "Value";
            cboEstado.SelectedIndex = 0;

            List<Categoria> listaCategorias = new cnCategoria().ListarCategorias();

            foreach (Categoria item in listaCategorias)
            {
                cboCategoria.Items.Add(new OpcionCombo { Texto = item.DESCRIPCION, Valor = item.IDCATEGORIA });
            }
            cboCategoria.DisplayMember = "Texto";
            cboCategoria.ValueMember = "Value";
            cboCategoria.SelectedIndex = 0;
        }

        private void cargarBusquedaColumnasTablaProductos()
        {
            foreach (DataGridViewColumn columna in dgvProductos.Columns)
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

        private void cargarUsuariosEnTablaProductos()
        {
            List<Producto> listaProductos = new cnProducto().ListarProductos();
            foreach (Producto item in listaProductos)
            {
                dgvProductos.Rows.Add(new object[] { "", item.IDPRODUCTO, item.CODIGO, item.NOMBRE, item.DESCRIPCION, 
                    item.oCATEGORIA.IDCATEGORIA,
                    item.oCATEGORIA.DESCRIPCION,
                    (item.oCATEGORIA.oMEDIDA.DESCRIPCION == "Kg" ? ((Convert.ToDecimal(item.STOCK))/1000).ToString("0.00") + " " + item.oCATEGORIA.oMEDIDA.DESCRIPCION : item.STOCK + " " + item.oCATEGORIA.oMEDIDA.DESCRIPCION),
                    //item.STOCK,
                    item.PRECIOCOMPRA,
                    item.PRECIOVENTA,
                    item.IMAGEN,
                    item.ESTADO == true ? 1 : 0,
                    item.ESTADO == true ? "Activo" : "No Activo"
                });
            }
        }

        private void limpiar()
        {
            txtIndice.Text = "-1";
            txtId.Text = "0";
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            pbProducto.Image = Properties.Resources.fotoVacia;
            cboCategoria.SelectedIndex = 0;
            cboEstado.SelectedIndex = 0;
            txtCodigo.Select();
        }

        private byte[] convertirImagenaBytes(Image imagen)
        {
            System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
            imagen.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
            byte[] imagenGuardada = memoryStream.GetBuffer();
            return imagenGuardada;
        }

        private void frmProductos_Load(object sender, EventArgs e)
        {
            cargarEstadoYCategorias();
            cargarBusquedaColumnasTablaProductos();
            cargarUsuariosEnTablaProductos();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            Producto producto = new Producto
            {
                IDPRODUCTO = Convert.ToInt32(txtId.Text),
                CODIGO = txtCodigo.Text,
                NOMBRE = txtNombre.Text,
                DESCRIPCION = txtDescripcion.Text,
                oCATEGORIA = new Categoria { IDCATEGORIA = Convert.ToInt32(((OpcionCombo)cboCategoria.SelectedItem).Valor) },
                IMAGEN = convertirImagenaBytes(pbProducto.Image),
                ESTADO = Convert.ToInt32(((OpcionCombo)cboEstado.SelectedItem).Valor) == 1 ? true : false
            };

            if (producto.IDPRODUCTO == 0)
            {
                int idProductoGenerado = new cnProducto().RegistrarProducto(producto, out mensaje);

                if (idProductoGenerado != 0)
                {
                    dgvProductos.Rows.Add(new object[] { "", idProductoGenerado, txtCodigo.Text, txtNombre.Text, txtDescripcion.Text,
                    ((OpcionCombo)cboCategoria.SelectedItem).Valor.ToString(),
                    ((OpcionCombo)cboCategoria.SelectedItem).Texto.ToString(),
                    "0",
                    "0.00",
                    "0.00",
                    convertirImagenaBytes(pbProducto.Image),
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
                bool resultado = new cnProducto().EditarProducto(producto, out mensaje);
                if (resultado)
                {
                    DataGridViewRow row = dgvProductos.Rows[Convert.ToInt32(txtIndice.Text)];
                    row.Cells["Id"].Value = txtId.Text;
                    row.Cells["Codigo"].Value = txtCodigo.Text;
                    row.Cells["Nombre"].Value = txtNombre.Text;
                    row.Cells["Descripcion"].Value = txtDescripcion.Text;
                    row.Cells["IdCategoria"].Value = ((OpcionCombo)cboCategoria.SelectedItem).Valor.ToString();
                    row.Cells["Categoria"].Value = ((OpcionCombo)cboCategoria.SelectedItem).Texto.ToString();
                    row.Cells["Imagen"].Value = convertirImagenaBytes(pbProducto.Image);
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

        private void dgvProductos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProductos.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    txtIndice.Text = indice.ToString();
                    txtId.Text = dgvProductos.Rows[indice].Cells["Id"].Value.ToString();
                    txtCodigo.Text = dgvProductos.Rows[indice].Cells["Codigo"].Value.ToString();
                    txtNombre.Text = dgvProductos.Rows[indice].Cells["Nombre"].Value.ToString();
                    txtDescripcion.Text = dgvProductos.Rows[indice].Cells["Descripcion"].Value.ToString();
                    foreach (OpcionCombo oc in cboCategoria.Items)
                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvProductos.Rows[indice].Cells["IdCategoria"].Value.ToString()))
                        {
                            int indiceCombo = cboCategoria.Items.IndexOf(oc);
                            cboCategoria.SelectedIndex = indiceCombo;
                            break;
                        }
                    }
                    foreach (OpcionCombo oc in cboEstado.Items)
                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvProductos.Rows[indice].Cells["EstadoValor"].Value.ToString()))
                        {
                            int indiceCombo = cboEstado.Items.IndexOf(oc);
                            cboEstado.SelectedIndex = indiceCombo;
                            break;
                        }
                    }
                    byte[] imagen = null;
                    if (dgvProductos.Rows[indice].Cells["Imagen"].Value == null)
                    {
                        pbProducto.Image = Properties.Resources.fotoVacia;  
                    }
                    else
                    {
                        imagen = (byte[])dgvProductos.Rows[indice].Cells["Imagen"].Value;
                        System.IO.MemoryStream memoryStream = new System.IO.MemoryStream(imagen);
                        pbProducto.Image = Image.FromStream(memoryStream);
                    }
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtId.Text) != 0)
            {
                if (MessageBox.Show("¿Desea eliminar el producto?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string mensaje = string.Empty;
                    Producto producto = new Producto { IDPRODUCTO = Convert.ToInt32(txtId.Text) };
                    bool respuesta = new cnProducto().EliminarProducto(producto, out mensaje);
                    if (respuesta)
                    {
                        dgvProductos.Rows.RemoveAt(Convert.ToInt32(txtIndice.Text));
                        limpiar();
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Problema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string columnaFiltro = ((OpcionCombo)cboBusqueda.SelectedItem).Valor.ToString();
            if (dgvProductos.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvProductos.Rows)
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
            foreach (DataGridViewRow row in dgvProductos.Rows)
            {
                row.Visible = true;
            }
        }

        private void btnSubirImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Seleccionar Imagen";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pbProducto.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if(dgvProductos.Rows.Count < 1)
            {
                MessageBox.Show("No hay productos para exportar", "Problema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                DataTable dt = new DataTable();
                foreach (DataGridViewColumn columna in dgvProductos.Columns)
                {
                    if(columna.HeaderText != "" && columna.Visible)
                    {
                        dt.Columns.Add(columna.HeaderText, typeof(string));
                    }
                }
                foreach (DataGridViewRow fila in dgvProductos.Rows)
                {
                    if (fila.Visible)
                    {
                        dt.Rows.Add(new object[]
                        {
                            fila.Cells[2].Value.ToString(),
                            fila.Cells[3].Value.ToString(),
                            fila.Cells[4].Value.ToString(),
                            fila.Cells[6].Value.ToString(),
                            fila.Cells[7].Value.ToString(),
                            fila.Cells[8].Value.ToString(),
                            fila.Cells[9].Value.ToString(),
                            fila.Cells[12].Value.ToString()
                        });
                    }
                }
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.FileName = string.Format("ReporteProductos_{0}.xlsx",DateTime.Now.ToString("ddMMyyyyHHmmss"));
                sfd.Filter = "Excel Files | *.xlsx";
                if(sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        XLWorkbook wb = new XLWorkbook();
                        var hoja = wb.Worksheets.Add(dt, "Informe");
                        hoja.ColumnsUsed().AdjustToContents();
                        wb.SaveAs(sfd.FileName);
                        MessageBox.Show("Reporte generado correctamente", "Reporte", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        MessageBox.Show("Ocurrio un error", "Reporte", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        private void btnCerrarModalProductos_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
