using CapaEntidad;
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
using CapaNegocio;
using DocumentFormat.OpenXml.Office2010.CustomUI;

namespace CapaPresentacion
{
    public partial class frmCompras : Form
    {
        private Usuario usuario;
        public frmCompras(Usuario usuario = null)
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
            txtIdProveedor.Text = "0";
        }

        private void limpiarProducto()
        {
            txtIdProducto.Text = "0";
            txtCodigoProducto.Text = "";
            txtCodigoProducto.BackColor = Color.White;
            txtProducto.Text = "";
            txtPrecioCompra.Text = "";
            txtPrecioVenta.Text = "";
            lblMedida.Text = "";
            nudCantidad.Value = 1;
        }

        private void calcularTotal()
        {
            decimal total = 0;
            if(dgvCompra.Rows.Count > 0)
            {
                foreach (DataGridViewRow fila in dgvCompra.Rows)
                {
                    total += Convert.ToDecimal(fila.Cells["Subtotal"].Value.ToString());
                }
            }
            txtTotalPagar.Text = total.ToString("0.00");
        }

        private void frmCompras_Load(object sender, EventArgs e)
        {
            cargarFechaActual();
            cargarTipoDocumento();
            cargarIdsImportantes();
        }

        private void btnBuscarNumeroDocumento_Click(object sender, EventArgs e)
        {
            using(var modalProveedor = new modalProveedor())
            {
                var result = modalProveedor.ShowDialog();
                if (result == DialogResult.OK)
                {
                    txtIdProveedor.Text = modalProveedor.proveedor.IDPROVEEDOR.ToString();
                    txtNumeroDocumento.Text = modalProveedor.proveedor.DOCUMENTO.ToString();
                    txtRazonSocial.Text = modalProveedor.proveedor.RAZONSOCIAL.ToString();
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
                    lblMedida.Text = (modalProducto.medida.DESCRIPCION.ToString() == "Kg" ? "G" : modalProducto.medida.DESCRIPCION.ToString());
                    txtPrecioCompra.Select();
                }
                else
                {
                    txtCodigoProducto.Select();
                }
            }
        }

        private void txtCodigoProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Enter)
            {
                Producto producto = new cnProducto().ListarProductos().Where(p => p.CODIGO == txtCodigoProducto.Text && p.ESTADO == true).FirstOrDefault();
                if(producto != null)
                {
                    txtCodigoProducto.BackColor = Color.Honeydew;
                    txtIdProducto.Text = producto.IDPRODUCTO.ToString();
                    txtProducto.Text = producto.NOMBRE.ToString();
                    txtPrecioCompra.Select();
                }
                else
                {
                    txtCodigoProducto.BackColor = Color.MistyRose;
                    txtIdProducto.Text = "0";
                    txtProducto.Text = "";
                }
            }
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            decimal preciocompra = 0;
            decimal precioventa = 0;
            bool productoExiste = false;

            if(int.Parse(txtIdProducto.Text) == 0) 
            {
                MessageBox.Show("Debe seleccionar un producto", "Advertencia",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }
            if (!decimal.TryParse(txtPrecioCompra.Text, out preciocompra))
            {
                MessageBox.Show("Precio Compra tiene el formato de moneda incorrecto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPrecioCompra.Select();
                return;
            }
            if (!decimal.TryParse(txtPrecioVenta.Text, out precioventa))
            {
                MessageBox.Show("Precio Venta tiene el formato de moneda incorrecto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPrecioVenta.Select();
                return;
            }
            if (Convert.ToInt32(nudCantidad.Text) == 0)
            {
                MessageBox.Show("La cantidad no puede ser cero", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            foreach (DataGridViewRow fila in dgvCompra.Rows)
            {
                if (fila.Cells["IdProducto"].Value.ToString() == txtIdProducto.Text)
                {
                    productoExiste = true;
                    break;
                }
            }
            if(!productoExiste)
            {
                dgvCompra.Rows.Add(new object[]
                {
                    txtIdProducto.Text,
                    txtProducto.Text,
                    preciocompra.ToString("0.00"),
                    precioventa.ToString("0.00"),
                    (lblMedida.Text == "G" ? (nudCantidad.Value/1000).ToString("0.00") + " Kg" : nudCantidad.Value.ToString() + " " + lblMedida.Text),
                    (lblMedida.Text == "G" ? ((nudCantidad.Value * preciocompra)/1000).ToString("0.00") : (nudCantidad.Value * preciocompra).ToString("0.00")) 
                });
                calcularTotal();
                limpiarProducto();
                txtCodigoProducto.Select();

            }
            else
            {
                MessageBox.Show("El producto ya se encuentra registrado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }

        }

        private void dgvCompra_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            if (e.ColumnIndex == 6)
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

        private void dgvCompra_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCompra.Columns[e.ColumnIndex].Name == "btnEliminar")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    dgvCompra.Rows.RemoveAt(indice);
                    calcularTotal();
                }
            }
        }

        private void txtPrecioCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (txtPrecioCompra.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
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

        private void txtPrecioVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (txtPrecioVenta.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
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

        private void btnRegistrarCompra_Click(object sender, EventArgs e)
        {
            decimal cantidad;

            if (Convert.ToInt32(txtIdProveedor.Text) == 0)
            {
                MessageBox.Show("Debe seleccionar un Proveedor", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if(dgvCompra.Rows.Count < 1) 
            {
                MessageBox.Show("Debe haber productos para poder comprar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DataTable dtDetalleCompra = new DataTable();
            dtDetalleCompra.Columns.Add("IDPRODUCTO", typeof(int));
            dtDetalleCompra.Columns.Add("PRECIOCOMPRA", typeof(decimal));
            dtDetalleCompra.Columns.Add("PRECIOVENTA", typeof(decimal));
            dtDetalleCompra.Columns.Add("CANTIDAD", typeof(int));
            dtDetalleCompra.Columns.Add("MONTOTOTAL", typeof(decimal));

            foreach (DataGridViewRow fila in dgvCompra.Rows)
            {
                dtDetalleCompra.Rows.Add(new object[] {
                    Convert.ToInt32(fila.Cells["IdProducto"].Value.ToString()),
                    fila.Cells["PrecioCompra"].Value.ToString(),
                    fila.Cells["PrecioVenta"].Value.ToString(),
                    (new string(fila.Cells["Cantidad"].Value.ToString().Reverse().Take(2).Reverse().ToArray()) == "Kg" ? (Convert.ToInt32(string.Concat(fila.Cells["Cantidad"].Value.ToString().Where(c => Char.IsDigit(c))))*10).ToString() : (Convert.ToInt32(string.Concat(fila.Cells["Cantidad"].Value.ToString().Where(c => Char.IsDigit(c))))).ToString()),
                    fila.Cells["Subtotal"].Value.ToString()
                });
            }
            
            int idIncrementable = new cnCompra().ObtenerIdIncrementable();
            string numeroDocumento = string.Format("{0:00000}", idIncrementable);

            Compra compra = new Compra
            {
                oUSUARIO = new Usuario { IDUSUARIO = usuario.IDUSUARIO },
                oPROVEEDOR = new Proveedor { IDPROVEEDOR = Convert.ToInt32(txtIdProveedor.Text) },
                TIPODOCUMENTO = ((OpcionCombo)cboTipoDocumento.SelectedItem).Texto,
                NUMERODOCUMENTO = numeroDocumento,
                MONTOTOTAL = Convert.ToDecimal(txtTotalPagar.Text)
            };

            string mensaje = string.Empty;

            bool respuesta = new cnCompra().RegistrarCompra(compra, dtDetalleCompra, out mensaje);

            if (respuesta)
            {
                var resultado = MessageBox.Show("Compra Generada Correctamente con el numero:\n" + numeroDocumento + "\n\n¿Desea copiar al portapapeles?", "Mensaje",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
                if(resultado == DialogResult.Yes)
                {
                    Clipboard.SetText(numeroDocumento);
                }
                txtIdProveedor.Text = "0";
                txtNumeroDocumento.Text = "";
                txtRazonSocial.Text = "";
                dgvCompra.Rows.Clear();
                calcularTotal();
            }
            else
            {
                MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }

        private void lblMedida_Click(object sender, EventArgs e)
        {

        }

        private void btnCerrarRegistrarVenta_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
