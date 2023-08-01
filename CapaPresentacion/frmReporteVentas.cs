using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utilidades;
using ClosedXML.Excel;
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
    public partial class frmReporteVentas : Form
    {
        public frmReporteVentas()
        {
            InitializeComponent();
        }

        private void frmReporteVentas_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn columna in dgvReporteVenta.Columns)
            {
                cboBusqueda.Items.Add(new OpcionCombo { Valor = columna.Name, Texto = columna.HeaderText });
            }
            cboBusqueda.DisplayMember = "Texto";
            cboBusqueda.ValueMember = "Valor";
            cboBusqueda.SelectedIndex = 0;
        }

        private void btnBuscarReporteVenta_Click(object sender, EventArgs e)
        {
            List<ReporteVenta> listaReporteVenta = new List<ReporteVenta>();
            listaReporteVenta = new cnReporte().ObtenerReporteVenta(dtpInicio.Value.ToString(), dtpFin.Value.ToString());

            dgvReporteVenta.Rows.Clear();

            foreach (ReporteVenta item in listaReporteVenta)
            {
                dgvReporteVenta.Rows.Add(new object[]
                {
                    item.FECHAREGISTRO,
                    item.TIPODOCUMENTO,
                    item.NUMERODOCUMENTO,
                    item.MONTOTOTAL,
                    item.USUARIOREGISTRO,
                    item.DOCUMENTOCLIENTE,
                    item.NOMBRECLIENTE,
                    item.CODIGOPRODUCTO,
                    item.NOMBREPRODUCTO,
                    item.CATEGORIA,
                    item.PRECIOVENTA,
                    (item.MEDIDA == "Kg" ? ((Convert.ToDecimal(item.CANTIDAD))/1000).ToString("0.00") + " Kg" : item.CANTIDAD + " " + item.MEDIDA),
                    item.SUBTOTAL
                });
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string columnaFiltro = ((OpcionCombo)cboBusqueda.SelectedItem).Valor.ToString();
            if (dgvReporteVenta.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvReporteVenta.Rows)
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
            foreach (DataGridViewRow row in dgvReporteVenta.Rows)
            {
                row.Visible = true;
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dgvReporteVenta.Rows.Count < 1)
            {
                MessageBox.Show("No se encontraron resultados para exportar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                DataTable dt = new DataTable();
                foreach (DataGridViewColumn columna in dgvReporteVenta.Columns)
                {
                    dt.Columns.Add(columna.HeaderText, typeof(string));
                }
                foreach (DataGridViewRow fila in dgvReporteVenta.Rows)
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
                            fila.Cells[12].Value.ToString()
                        });
                    }
                }
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.FileName = string.Format("ReporteVentas_{0}.xlsx", DateTime.Now.ToString("ddMMyyyyHHmmss"));
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

        private void btnCerrarRegistrarVenta_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
