using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Modales;
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
    public partial class frmVentas : Form
    {
        private Usuario usuario;
        public frmVentas(Usuario usuario = null)
        {
            this.usuario = usuario;
            InitializeComponent();
        }

        private void cargarTipoDocumento()
        {
            cboTipoDocumento.Items.Add(new OpcionCombo { Texto = "Boleta", Valor = "Boleta" });
            cboTipoDocumento.Items.Add(new OpcionCombo { Texto = "Factura", Valor = "Factura" });
            cboTipoDocumento.DisplayMember = "Texto";
            cboTipoDocumento.ValueMember = "Value";
            cboTipoDocumento.SelectedIndex = 0;
        }

        private void cargarFechaActual()
        {
            txtFecha.Text = DateTime.Now.ToString("dd//MM/yyyy");
        }

        private void cargarIdsImportantes()
        {
            txtIdProducto.Text = "0";
            txtPagoCon.Text = "";
            txtCambio.Text = "";
            txtTotalPagar.Text = "0";
        }

        private void calcularTotal()
        {
            decimal total = 0;
            if (dgvVenta.Rows.Count > 0)
            {
                foreach (DataGridViewRow fila in dgvVenta.Rows)
                {
                    total += Convert.ToDecimal(fila.Cells["Subtotal"].Value.ToString());
                }
            }
            txtTotalPagar.Text = total.ToString("0.00");
        }

        private void calcularCambio() 
        {
            if(txtTotalPagar.Text.Trim() == "") 
            {
                MessageBox.Show("No existen productos en la venta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            decimal pagacon;
            decimal total = Convert.ToDecimal(txtTotalPagar.Text);
            
            if (txtPagoCon.Text.Trim() == "")
                txtPagoCon.Text = "0";

            if (decimal.TryParse(txtPagoCon.Text.Trim(), out pagacon))
            {
                if (pagacon < total)
                    txtCambio.Text = "0.00";
                else
                {
                    decimal cambio = pagacon - total;
                    txtCambio.Text = cambio.ToString("0.00");
                }
                   
            }
        }

        private void limpiarProducto()
        {
            txtIdProducto.Text = "0";
            txtCodigoProducto.Text = "";
            txtCodigoProducto.BackColor = Color.White;
            txtProducto.Text = "";
            txtStock.Text = "";
            txtPrecio.Text = "";
            nudCantidad.Value = 1;
            lblMedida.Text = "";
        }

        private void frmVentas_Load(object sender, EventArgs e)
        {
            cargarFechaActual();
            cargarTipoDocumento();
            cargarIdsImportantes();
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            using (var modalCliente = new modalCliente())
            {
                var result = modalCliente.ShowDialog();
                if (result == DialogResult.OK)
                {
                    txtNumeroDocumento.Text = modalCliente.cliente.DOCUMENTO.ToString();
                    txtNombreCliente.Text = modalCliente.cliente.NOMBRECOMPLETO.ToString();
                    txtIdProducto.Select();
                }
                else
                {
                    txtNumeroDocumento.Select();
                }
            }
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            using (var modalProducto = new modalProducto())
            {
                var result = modalProducto.ShowDialog();
                if (result == DialogResult.OK)
                {
                    txtIdProducto.Text = modalProducto.producto.IDPRODUCTO.ToString();
                    txtCodigoProducto.Text = modalProducto.producto.CODIGO.ToString();
                    txtProducto.Text = modalProducto.producto.NOMBRE.ToString();
                    txtPrecio.Text = modalProducto.producto.PRECIOVENTA.ToString("0.00");
                    txtStock.Text = modalProducto.producto.STOCK.ToString();
                    lblMedida.Text = (modalProducto.medida.DESCRIPCION.ToString() == "Kg" ? "G" : modalProducto.medida.DESCRIPCION.ToString());
                    nudCantidad.Select();
                }
                else
                {
                    txtCodigoProducto.Select();
                }
            }
        }

        private void txtCodigoProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                Producto producto = new cnProducto().ListarProductos().Where(p => p.CODIGO == txtCodigoProducto.Text && p.ESTADO == true).FirstOrDefault();
                if (producto != null)
                {
                    txtCodigoProducto.BackColor = Color.Honeydew;
                    txtIdProducto.Text = producto.IDPRODUCTO.ToString();
                    txtProducto.Text = producto.NOMBRE.ToString();
                    txtPrecio.Text = producto.PRECIOVENTA.ToString("0.00");
                    txtStock.Text = producto.STOCK.ToString();
                    nudCantidad.Select();
                }
                else
                {
                    txtCodigoProducto.BackColor = Color.MistyRose;
                    txtIdProducto.Text = "0";
                    txtProducto.Text = "";
                    txtPrecio.Text = "";
                    txtStock.Text = "";
                    nudCantidad.Value = 1;
                }
            }
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            decimal precio = 0;
            bool productoExiste = false;

            if (int.Parse(txtIdProducto.Text) == 0)
            {
                MessageBox.Show("Debe seleccionar un producto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (!decimal.TryParse(txtPrecio.Text, out precio))
            {
                MessageBox.Show("Precio tiene el formato de moneda incorrecto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPrecio.Select();
                return;
            }
            if(Convert.ToInt32(nudCantidad.Text) == 0)
            {
                MessageBox.Show("La cantidad no puede ser cero", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (Convert.ToInt32(txtStock.Text) < Convert.ToInt32(nudCantidad.Value.ToString()))
            {
                MessageBox.Show("La cantidad no puede ser mayor al Stock", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            foreach (DataGridViewRow fila in dgvVenta.Rows)
            {
                if (fila.Cells["IdProducto"].Value.ToString() == txtIdProducto.Text)
                {
                    productoExiste = true;
                    break;
                }
            }
            if (!productoExiste)
            {
                bool respuesta = new cnVenta().RestarStock(Convert.ToInt32(txtIdProducto.Text), Convert.ToInt32(nudCantidad.Value.ToString()));

                if (respuesta)
                {
                    dgvVenta.Rows.Add(new object[]
                    {
                        txtIdProducto.Text,
                        txtProducto.Text,
                        precio.ToString("0.00"),
                        (lblMedida.Text == "G" ? (nudCantidad.Value/1000).ToString("0.00") + " Kg" : nudCantidad.Value.ToString() + " " + lblMedida.Text),
                        (lblMedida.Text == "G" ? ((nudCantidad.Value * precio)/1000).ToString("0.00") : (nudCantidad.Value * precio).ToString("0.00"))
                    });
                    calcularTotal();
                    calcularCambio();
                    limpiarProducto();
                    txtCodigoProducto.Select();
                }               
            }
            else
            {
                MessageBox.Show("El producto ya se encuentra agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }

        private void dgvVenta_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            if (e.ColumnIndex == 5)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var w = Properties.Resources.trashCompra.Width;
                var h = Properties.Resources.trashCompra.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;
                e.Graphics.DrawImage(Properties.Resources.trashCompra, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        private void dgvVenta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvVenta.Columns[e.ColumnIndex].Name == "btnEliminar")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    bool respuesta = new cnVenta().SumarStock(
                        Convert.ToInt32(dgvVenta.Rows[indice].Cells["IdProducto"].Value.ToString()), 
                        (Convert.ToInt32(string.Concat(dgvVenta.Rows[indice].Cells["Cantidad"].Value.ToString().Where(c => Char.IsDigit(c)))) * 10)
                    );
                    if (respuesta)
                    {
                        dgvVenta.Rows.RemoveAt(indice);
                        calcularTotal();
                        calcularCambio();
                    }
                }
            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (txtPrecio.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
                {
                    e.Handled = true;
                }
                else
                {
                    if (Char.IsControl(e.KeyChar) || e.KeyChar.ToString() == ".")
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void txtPagoCon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (txtPagoCon.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
                {
                    e.Handled = true;
                }
                else
                {
                    if (Char.IsControl(e.KeyChar) || e.KeyChar.ToString() == ".")
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void txtPagoCon_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Enter) 
            {
                calcularCambio();
            }
        }

        private void btnRegistrarVenta_Click(object sender, EventArgs e)
        {
            if(txtNumeroDocumento.Text == "")
            {
                MessageBox.Show("Debe ingresar el documento del cliente", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (txtNombreCliente.Text == "")
            {
                MessageBox.Show("Debe ingresar el nombre del cliente", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (dgvVenta.Rows.Count < 1)
            {
                MessageBox.Show("Debe ingresar productos en la venta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DataTable dtDetalleVenta = new DataTable();
            dtDetalleVenta.Columns.Add("IDPRODUCTO", typeof(int));
            dtDetalleVenta.Columns.Add("PRECIOVENTA", typeof(decimal));
            dtDetalleVenta.Columns.Add("CANTIDAD", typeof(int));
            dtDetalleVenta.Columns.Add("SUBTOTAL", typeof(decimal));

            foreach (DataGridViewRow fila in dgvVenta.Rows)
            {
                dtDetalleVenta.Rows.Add(new object[] {
                    fila.Cells["IdProducto"].Value.ToString(),
                    fila.Cells["Precio"].Value.ToString(),
                    (new string(fila.Cells["Cantidad"].Value.ToString().Reverse().Take(2).Reverse().ToArray()) == "Kg" ? (Convert.ToInt32(string.Concat(fila.Cells["Cantidad"].Value.ToString().Where(c => Char.IsDigit(c))))*10).ToString() : (Convert.ToInt32(string.Concat(fila.Cells["Cantidad"].Value.ToString().Where(c => Char.IsDigit(c))))).ToString()),
                    fila.Cells["Subtotal"].Value.ToString()
                });
            }

            int idIncrementable = new cnVenta().ObtenerIdIncrementable();
            string numeroDocumento = string.Format("{0:00000}", idIncrementable);

            Venta venta = new Venta
            {
                oUSUARIO = new Usuario { IDUSUARIO = usuario.IDUSUARIO },
                TIPODOCUMENTO = ((OpcionCombo)cboTipoDocumento.SelectedItem).Texto,
                NUMERODOCUMENTO = numeroDocumento,
                DOCUMENTOCLIENTE = txtNumeroDocumento.Text,
                NOMBRECLIENTE = txtNombreCliente.Text,
                MONTOPAGO = Convert.ToDecimal(txtPagoCon.Text),
                MONTOCAMBIO = Convert.ToDecimal(txtCambio.Text),
                MONTOTOTAL = Convert.ToDecimal(txtTotalPagar.Text)
            };

            string mensaje = string.Empty;

            bool respuesta = new cnVenta().RegistrarVenta(venta, dtDetalleVenta, out mensaje);

            if (respuesta)
            {
                var resultado = MessageBox.Show("Venta Generada Correctamente con el numero:\n" + numeroDocumento + "\n\n¿Desea copiar al portapapeles?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (resultado == DialogResult.Yes)
                {
                    Clipboard.SetText(numeroDocumento);
                }
                txtNumeroDocumento.Text = "";
                txtNombreCliente.Text = "";
                dgvVenta.Rows.Clear();
                calcularTotal();
                txtPagoCon.Text = "";
                txtCambio.Text = "";
            }
            else
            {
                MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }

        private void btnCerrarRegistrarVenta_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
