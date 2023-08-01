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
using CapaEntidad;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class frmNegocio : Form
    {
        public frmNegocio()
        {
            InitializeComponent();
        }

        public Image ConvertirBytesaImagen(byte[] imagenByte)
        {
            MemoryStream ms = new MemoryStream();
            ms.Write(imagenByte, 0, imagenByte.Length);
            Image image = new Bitmap(ms);
            return image;
        }

        private void frmNegocio_Load(object sender, EventArgs e)
        {
            bool respuesta = true;
            byte[] imagenByte = new cnNegocio().RecuperarLogo(out respuesta);
            if (respuesta)
                pbLogo.Image = ConvertirBytesaImagen(imagenByte);
            Negocio negocio = new cnNegocio().ObtenerDatos();
            txtNombre.Text = negocio.NOMBRE.ToString();
            txtRUC.Text = negocio.RUC.ToString();
            txtDireccion.Text = negocio.DIRECCION.ToString();
        }

        private void btnSubirLogo_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = "Files | *.jpeg;*.jpg;*.png";
            if(ofd.ShowDialog() == DialogResult.OK) 
            {
                byte[] imagenByte = File.ReadAllBytes(ofd.FileName);
                bool respuesta = new cnNegocio().ActualzarLogo(imagenByte, out mensaje);
                if (respuesta)
                    pbLogo.Image = ConvertirBytesaImagen(imagenByte);
                else
                    MessageBox.Show(mensaje, "Error",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            Negocio negocio = new Negocio
            {
                NOMBRE = txtNombre.Text,
                RUC = txtRUC.Text,
                DIRECCION = txtDireccion.Text,
            };
            bool respuesta = new cnNegocio().GuardarDatos(negocio, out mensaje);
            if(respuesta)
                MessageBox.Show("Cambios Guardados Correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se logro guardar los cambios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void iconButton2_Click(object sender, EventArgs e)
        {

        }

        private void btnCerrarModalNegocio_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
