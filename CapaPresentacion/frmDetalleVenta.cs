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
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System.IO;
using iTextSharp.text;

namespace CapaPresentacion
{
    public partial class frmDetalleVenta : Form
    {
        public frmDetalleVenta()
        {
            InitializeComponent();
        }

        private void frmDetalleVenta_Load(object sender, EventArgs e)
        {
            txtBusqueda.Select();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvDetalleVenta.Rows.Clear();
            Venta venta = new cnVenta().ObtenerVenta(txtBusqueda.Text);
            if(venta.IDVENTA != 0)
            {
                txtNumeroDocumento.Text = venta.NUMERODOCUMENTO;
                txtFecha.Text = venta.FECHAREGISTRO;
                txtTipoDocumento.Text = venta.TIPODOCUMENTO;
                txtUsuario.Text = venta.oUSUARIO.NOMBRECOMPLETO;
                txtNumeroDocumento.Text = venta.DOCUMENTOCLIENTE;
                txtNombreCompleto.Text = venta.NOMBRECLIENTE;
                txtNumeroVenta.Text = venta.NUMERODOCUMENTO;

                foreach (DetalleVenta dv in venta.oDETALLEVENTA)
                {
                    dgvDetalleVenta.Rows.Add(new object[]
                    {
                        dv.oPRODUCTO.NOMBRE,
                        dv.PRECIOVENTA,
                        (dv.oPRODUCTO.oCATEGORIA.oMEDIDA.DESCRIPCION == "Kg" ? ((Convert.ToDecimal(dv.CANTIDAD))/1000).ToString("0.00") + " Kg" : dv.CANTIDAD + " " + dv.oPRODUCTO.oCATEGORIA.oMEDIDA.DESCRIPCION),
                        dv.SUBTOTAL
                    });
                }

                txtMontoTotal.Text = venta.MONTOTOTAL.ToString();
                txtMontoPago.Text = venta.MONTOPAGO.ToString();
                txtMontoCambio.Text = venta.MONTOCAMBIO.ToString();
            } 
        }

        private void btnLimpiarBuscador_Click(object sender, EventArgs e)
        {
            txtFecha.Text = "";
            txtTipoDocumento.Text = "";
            txtUsuario.Text = "";
            txtNumeroDocumento.Text = "";
            txtNombreCompleto.Text = "";
            txtNumeroVenta.Text = "";
            dgvDetalleVenta.Rows.Clear();
            txtMontoTotal.Text = "0.00";
            txtMontoPago.Text = "0.00";
            txtMontoCambio.Text = "0.00";
            txtBusqueda.Select();
        }

        private void btnDescargarPdf_Click(object sender, EventArgs e)
        {
            if (txtNumeroVenta.Text == "")
            {
                MessageBox.Show("No se encontraron resultados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string textoHtml = Properties.Resources.PlantillaDetalleVenta.ToString();

            Negocio negocio = new cnNegocio().ObtenerDatos();

            textoHtml = textoHtml.Replace("@nombrenegocio", negocio.NOMBRE.ToUpper());
            textoHtml = textoHtml.Replace("@docnegocio", negocio.RUC);
            textoHtml = textoHtml.Replace("@direcnegocio", negocio.DIRECCION);

            textoHtml = textoHtml.Replace("@tipodocumento", txtTipoDocumento.Text.ToUpper());
            textoHtml = textoHtml.Replace("@numerodocumento", txtNumeroVenta.Text);

            textoHtml = textoHtml.Replace("@doccliente", txtNumeroDocumento.Text);
            textoHtml = textoHtml.Replace("@nombrecliente", txtNombreCompleto.Text);
            textoHtml = textoHtml.Replace("@fecharegistro", txtFecha.Text);
            textoHtml = textoHtml.Replace("@usuarioregistro", txtUsuario.Text);

            string filas = string.Empty;
            foreach (DataGridViewRow fila in dgvDetalleVenta.Rows)
            {
                filas += "<tr>";
                filas += "<td>" + fila.Cells["Producto"].Value.ToString() + "</td>";
                filas += "<td>" + fila.Cells["Precio"].Value.ToString() + "</td>";
                filas += "<td>" + fila.Cells["Cantidad"].Value.ToString() + "</td>";
                filas += "<td>" + fila.Cells["Subtotal"].Value.ToString() + "</td>";
                filas += "</tr>";
            }

            textoHtml = textoHtml.Replace("@filas", filas);
            textoHtml = textoHtml.Replace("@montototal", txtMontoTotal.Text);
            textoHtml = textoHtml.Replace("@pagocon", txtMontoPago.Text);
            textoHtml = textoHtml.Replace("@cambio", txtMontoCambio.Text);


            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = string.Format("Venta_{0}.pdf", txtNumeroVenta.Text);
            sfd.Filter = "Pdf Files|*.pdf";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fileStream = new FileStream(sfd.FileName, FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);
                    PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, fileStream);
                    pdfDoc.Open();

                    bool respuesta = true;
                    byte[] imagenByte = new cnNegocio().RecuperarLogo(out respuesta);
                    if (respuesta)
                    {
                        iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(imagenByte);
                        img.ScaleToFit(60, 60);
                        img.Alignment = iTextSharp.text.Image.UNDERLYING;
                        img.SetAbsolutePosition(pdfDoc.Left, pdfDoc.GetTop(51));
                        pdfDoc.Add(img);
                    }

                    using (StringReader sr = new StringReader(textoHtml))
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(pdfWriter, pdfDoc, sr);
                    }

                    pdfDoc.Close();
                    fileStream.Close();
                    MessageBox.Show("Pdf Generado Correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
        }

        private void btnCerrarDetalleVenta_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
