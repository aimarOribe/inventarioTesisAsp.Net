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
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System.IO;

namespace CapaPresentacion
{
    public partial class frmDetalleCompra : Form
    {
        public frmDetalleCompra()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Compra compra = new cnCompra().ObtenerCompra(txtBusqueda.Text);
            if(compra.IDCOMPRA != 0)
            {
                txtNumeroCompra.Text = compra.NUMERODOCUMENTO;
                txtFecha.Text = compra.FECHAREGISTRO;
                txtTipoDocumento.Text = compra.TIPODOCUMENTO;
                txtUsuario.Text = compra.oUSUARIO.NOMBRECOMPLETO;
                txtNumeroDocumento.Text = compra.oPROVEEDOR.DOCUMENTO;
                txtRazonSocial.Text = compra.oPROVEEDOR.RAZONSOCIAL;

                dgvDetalleCompra.Rows.Clear();

                foreach (DetalleCompra dc in compra.oDETALLECOMPRA)
                {
                    dgvDetalleCompra.Rows.Add(new object[]
                    {
                        dc.oPRODUCTO.NOMBRE,
                        dc.PRECIOCOMPRA,
                        (dc.oPRODUCTO.oCATEGORIA.oMEDIDA.DESCRIPCION == "Kg" ? ((Convert.ToDecimal(dc.CANTIDAD))/1000).ToString("0.00") + " Kg" : dc.CANTIDAD + " " + dc.oPRODUCTO.oCATEGORIA.oMEDIDA.DESCRIPCION),
                        dc.MONTOTOTAL
                    });
                }
                txtMontoTotal.Text = compra.MONTOTOTAL.ToString("0.00");
            }
        }

        private void btnLimpiarBuscador_Click(object sender, EventArgs e)
        {
            txtFecha.Text = "";
            txtTipoDocumento.Text = "";
            txtUsuario.Text = "";
            txtNumeroDocumento.Text = "";
            txtRazonSocial.Text = "";
            txtMontoTotal.Text = "";
            txtNumeroCompra.Text = "";
            dgvDetalleCompra.Rows.Clear();
            txtBusqueda.Select();
        }

        private void btnDescargarPdf_Click(object sender, EventArgs e)
        {
            if(txtNumeroCompra.Text == "")
            {
                MessageBox.Show("No se encontraron resultados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string textoHtml = Properties.Resources.plantillaDetalleCompra.ToString();

            Negocio negocio = new cnNegocio().ObtenerDatos();

            textoHtml = textoHtml.Replace("@nombrenegocio", negocio.NOMBRE.ToUpper());
            textoHtml = textoHtml.Replace("@docnegocio", negocio.RUC);
            textoHtml = textoHtml.Replace("@direcnegocio", negocio.DIRECCION);

            textoHtml = textoHtml.Replace("@tipodocumento", txtTipoDocumento.Text.ToUpper());
            textoHtml = textoHtml.Replace("@numerodocumento", txtNumeroCompra.Text);

            textoHtml = textoHtml.Replace("@docproveedor", txtNumeroDocumento.Text);
            textoHtml = textoHtml.Replace("@nombreproveedor", txtRazonSocial.Text);
            textoHtml = textoHtml.Replace("@fecharegistro", txtFecha.Text);
            textoHtml = textoHtml.Replace("@usuarioregistro", txtUsuario.Text);

            string filas = string.Empty;
            foreach (DataGridViewRow fila in dgvDetalleCompra.Rows)
            {
                filas += "<tr>";
                filas += "<td>" + fila.Cells["Producto"].Value.ToString() + "</td>";
                filas += "<td>" + fila.Cells["PrecioCompra"].Value.ToString() + "</td>";
                filas += "<td>" + fila.Cells["Cantidad"].Value.ToString() + "</td>";
                filas += "<td>" + fila.Cells["Subtotal"].Value.ToString() + "</td>";
                filas += "</tr>";
            }

            textoHtml = textoHtml.Replace("@filas", filas);
            textoHtml = textoHtml.Replace("@montototal", txtMontoTotal.Text);


            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = string.Format("Compra_{0}.pdf", txtNumeroCompra.Text);
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
                        img.ScaleToFit(60,60);
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

        private void frmDetalleCompra_Load(object sender, EventArgs e)
        {

        }

        private void btnCerrarDetalleCompra_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
