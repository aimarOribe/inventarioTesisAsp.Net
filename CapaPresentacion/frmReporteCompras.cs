using CapaEntidad;
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
using CapaPresentacion.Utilidades;
using ClosedXML.Excel;

namespace CapaPresentacion
{
    public partial class frmReporteCompras : Form
    {
        public frmReporteCompras()
        {
            InitializeComponent();
        }

        private void frmReporteCompras_Load(object sender, EventArgs e)
        {
            List<Proveedor> listaProveedores = new cnProveedor().ListarProveedor();
            cboProveedor.Items.Add(new OpcionCombo { Valor = 0, Texto = "Todos" });
            foreach (Proveedor item in listaProveedores)
            {
                cboProveedor.Items.Add(new OpcionCombo { Valor = item.IDPROVEEDOR, Texto = item.RAZONSOCIAL });
            }
            cboProveedor.DisplayMember = "Texto";
            cboProveedor.ValueMember = "Valor";
            cboProveedor.SelectedIndex = 0;

            foreach (DataGridViewColumn columna in dgvReporteCompras.Columns)
            {
                cboBusqueda.Items.Add(new OpcionCombo { Valor = columna.Name, Texto = columna.HeaderText });
            }
            cboBusqueda.DisplayMember = "Texto";
            cboBusqueda.ValueMember = "Valor";
            cboBusqueda.SelectedIndex = 0;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscarReporteCompra_Click(object sender, EventArgs e)
        {
            int idProveedor = Convert.ToInt32(((OpcionCombo)cboProveedor.SelectedItem).Valor.ToString());
            List<ReporteCompra> listaReporteCompra = new List<ReporteCompra>();
            listaReporteCompra = new cnReporte().ObtenerReporteCompra(dtpInicio.Value.ToString(),dtpFin.Value.ToString(),idProveedor);
            
            dgvReporteCompras.Rows.Clear();

            foreach (ReporteCompra item in listaReporteCompra)
            {
                dgvReporteCompras.Rows.Add(new object[]
                {
                    item.FECHAREGISTRO,
                    item.TIPODOCUMENTO,
                    item.NUMERODOCUMENTO,
                    item.MONTOTOTAL,
                    item.USUARIOREGISTRO,
                    item.DOCUMENTOPROVEEDOR,
                    item.RAZONSOCIAL,
                    item.CODIGOPRODUCTO,
                    item.NOMBREPRODUCTO,
                    item.CATEGORIA,
                    item.PRECIOCOMPRA,
                    item.PRECIOVENTA,
                    (item.MEDIDA == "Kg" ? ((Convert.ToDecimal(item.CANTIDAD))/1000).ToString("0.00") + " Kg" : item.CANTIDAD + " " + item.MEDIDA),
                    item.SUBTOTAL
                });
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if(dgvReporteCompras.Rows.Count < 1)
            {
                MessageBox.Show("No se encontraron resultados para exportar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                DataTable dt = new DataTable();
                foreach (DataGridViewColumn columna in dgvReporteCompras.Columns)
                {
                    dt.Columns.Add(columna.HeaderText, typeof(string));
                }
                foreach (DataGridViewRow fila in dgvReporteCompras.Rows)
                {
                    if (fila.Visible)
                    {
                        dt.Rows.Add(new object[]
                        {
                            fila.Cells[0].Value.ToString(),
                            fila.Cells[1].Value.ToString(),
                            fila.Cells[2].Value.ToString(),
                            fila.Cells[3].Value.ToString(),
                            fila.Cells[4].Value.ToString(),
                            fila.Cells[5].Value.ToString(),
                            fila.Cells[6].Value.ToString(),
                            fila.Cells[7].Value.ToString(),
                            fila.Cells[8].Value.ToString(),
                            fila.Cells[9].Value.ToString(),
                            fila.Cells[10].Value.ToString(),
                            fila.Cells[11].Value.ToString(),
                            fila.Cells[12].Value.ToString(),
                            fila.Cells[13].Value.ToString()
                        });
                    }
                }
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.FileName = string.Format("ReporteCompras_{0}.xlsx", DateTime.Now.ToString("ddMMyyyyHHmmss"));
                sfd.Filter = "Excel Files | *.xlsx";
                if (sfd.ShowDialog() == DialogResult.OK)
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string columnaFiltro = ((OpcionCombo)cboBusqueda.SelectedItem).Valor.ToString();
            if (dgvReporteCompras.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvReporteCompras.Rows)
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
            foreach (DataGridViewRow row in dgvReporteCompras.Rows)
            {
                row.Visible = true;
            }
        }

        private void btnCerrarReporteCompras_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
